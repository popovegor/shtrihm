// StartLock.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"

//#include "StartLock.h"

#include "winfind.h"

#include <Aygshell.h>
#pragma comment(lib,"aygshell.lib")

#include "Pkfuncs.h" //SetProcPermissions

#define DLL_NAME             L"StartLock.dll"
#define DLL_VERSION_MAJOR    1
#define DLL_VERSION_MINOR    1
#define DLL_VERSION_BUILD    1
#define DLL_VERSION_REVISION 0

void ShowError(LONG);

//globals
int MAX_START_X = 120;
const int MAX_START_Y = 28;

//some globals
static HWND hWndLockdown = 0;
static WNDPROC oldWindowProc = NULL;
static HWND taskbarhWnd;
static bool bStartbarLocked=false;
static bool bStartmenuLocked=false;
static bool bLockedDown=false;

//forward declarations
LRESULT CALLBACK TaskbarWindowProc(HWND, UINT, WPARAM, LPARAM);	// this is the new window proc, checks for click on Start
void __stdcall LockStartMenu();			// this will install the hook (subclass the taskbar window)
void __stdcall UnlockStartMenu();		// this will unhook TaskbarWindowProc from taskbar
void __stdcall LockStartBar();			// this disables the whole taskbar
void __stdcall UnlockStartBar();		// this enables the taskbar window
bool __stdcall Lockdown(TCHAR*);		// this will make the application with the window title fullscreen etc
bool __stdcall Unlockdown();			// this will 'normalize' the fullscreen window
void ShowError(LONG);

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    switch (ul_reason_for_call)
    {
        case DLL_PROCESS_ATTACH:
			break;
        case DLL_THREAD_ATTACH:
			break;
        case DLL_THREAD_DETACH:
			break;
        case DLL_PROCESS_DETACH:
			UnlockStartBar();
			UnlockStartMenu();
            break;
    }
	SetProcPermissions(0xffffffff);
	
	int screenwidth = GetSystemMetrics(SM_CXSCREEN);
	if(screenwidth!=0)
		MAX_START_X = (int)(screenwidth * 2 / 3);

return TRUE;
}

//=============================================================================
// TaskbarWindowProc
//=============================================================================
// Used to Disable the Taskbar
LRESULT CALLBACK TaskbarWindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	if (message == WM_LBUTTONDOWN)
	{
		// See if the point where the stylus is pressing could activate the start button.
		POINTS pts;
		pts.x = LOWORD(lParam);
		pts.y = HIWORD(lParam);

		//the hot area of the StartMenu extends with the length of the current window title text
		//we get the actual screen width and then assume half the width as hot area
		int screenwidth = GetSystemMetrics(SM_CXSCREEN);
		if(screenwidth!=0)
			MAX_START_X = (int)(screenwidth * 2 / 3);

		#ifdef DEBUG
			DEBUGMSG(1, (L"got LButtonDown at x=%i, y=%i\n", pts.x, pts.y));
		#endif
		if (pts.y < MAX_START_Y && pts.x < MAX_START_X){
			#ifdef DEBUG
				DEBUGMSG(1, (L"ignoring lButtonDown\n"));
			#endif
			return TRUE;
		}
	}

	// win key would bring up start menu: WM_KEYDOWN = 0x100, VK_LWIN = 0x5B
	if (message == WM_KEYDOWN && wParam == VK_LWIN && lParam == 1)       
	return TRUE;

	return CallWindowProc(oldWindowProc, hWnd, message, wParam, lParam);
}

//=============================================================================
// LockStartMenu
//=============================================================================
void __stdcall LockStartMenu()
{
	if(!bStartmenuLocked){
		//Disable Keys going to the CE Taskbar
		taskbarhWnd = FindWindow(TEXT("HHTaskBar"), NULL); 
		if (taskbarhWnd != NULL)
		{
			WNDPROC p = TaskbarWindowProc;
			oldWindowProc = (WNDPROC)SetWindowLong(taskbarhWnd, GWL_WNDPROC, (long)p);
			#ifdef DEBUG
				if(oldWindowProc==NULL)
					ShowError(GetLastError());
				else
					DEBUGMSG(1, (L"SetWindowLong success\n"));
			#endif
		}
		bStartmenuLocked=true;
	}
}

//=============================================================================
// UnlockStartMenu
//=============================================================================
//__declspec(dllexport) void UnlockStartMenu()
void __stdcall UnlockStartMenu()
{
	if(bStartmenuLocked){
		if (oldWindowProc!=NULL)
			oldWindowProc = (WNDPROC)SetWindowLong(taskbarhWnd, GWL_WNDPROC, (long)oldWindowProc);

		oldWindowProc = NULL;
		bStartmenuLocked=false;
	}
}

//=============================================================================
// LockStartMenu2
//=============================================================================
//__declspec(dllexport) void LockStartMenu()
void __stdcall LockStartBar()
{
   //Disable the whole HHTaskbar window
	if(!bStartbarLocked){
		taskbarhWnd = FindWindow(TEXT("HHTaskBar"), NULL); 
		if (taskbarhWnd != NULL)
		{
			EnableWindow(taskbarhWnd, false);
			bStartbarLocked=true;
		}
	}
}

//=============================================================================
// UnlockStartMenu2
//=============================================================================
//__declspec(dllexport) void UnlockStartMenu()
void __stdcall UnlockStartBar()
{
    if (bStartbarLocked)
	{
	   taskbarhWnd = FindWindow(TEXT("HHTaskBar"), NULL); 
	   if (taskbarhWnd != NULL)
	   {
			EnableWindow(taskbarhWnd, true);
			bStartbarLocked=false;
	   }
	}
}

//=============================================================================
// Lockdown
//=============================================================================
//__declspec(dllexport) bool Lockdown(TCHAR *windowText)
bool __stdcall Lockdown(TCHAR *windowText)
{
	// If the application is already locked down, don't attempt to lock it down again.
	/*if (hWndLockdown)
		return TRUE;
	if(!bLockedDown){*/
		HWND hWnd = 0;

		TCHAR *str;
		str = (TCHAR*) malloc( MAX_PATH * sizeof(TCHAR)); 
		wcscpy (str, windowText);
		if ((!str) || (wcslen(str) <= 0))
			hWnd = FindRootWindowByFocus();
		else
			hWnd = FindRootWindowByName(str);

		if (!hWnd)
			return FALSE;

		free(str);

		SetForegroundWindow(hWnd);     // Required before SHFullScreen Calls
		SHDoneButton(hWnd, SHDB_HIDE);
		SHFullScreen(hWnd, SHFS_HIDESTARTICON|SHFS_HIDETASKBAR|SHFS_HIDESIPBUTTON);
		MoveWindow(hWnd, 0,0, 480,640, TRUE);  // Expand to use the entire screen

		hWndLockdown = hWnd;

		LockStartMenu();
		bLockedDown=true;
	//}
	return TRUE;
}

//=============================================================================
// Unlockdown
//=============================================================================
//__declspec(dllexport) bool Unlockdown()
bool __stdcall Unlockdown()
{
	if (!hWndLockdown)
		return FALSE;
	if(bLockedDown){
		SetForegroundWindow(hWndLockdown);     // Required before SHFullScreen Calls
		SHFullScreen(hWndLockdown, SHFS_SHOWSTARTICON|SHFS_SHOWTASKBAR|SHFS_SHOWSIPBUTTON);	
		MoveWindow(hWndLockdown, 0, 26, 480,640, TRUE);  // Expand to use the entire screen

		hWndLockdown = 0;
		bLockedDown=false;
		UnlockStartMenu();
	}
	return TRUE;
}

//=============================================================================
// ShowError
//=============================================================================
void ShowError(LONG er)
{
	LPVOID lpMsgBuf;
	FormatMessage( 
		FORMAT_MESSAGE_ALLOCATE_BUFFER | 
		FORMAT_MESSAGE_FROM_SYSTEM | 
		FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL,
		er,
		0, // Default language
		(LPTSTR) &lpMsgBuf,
		0,
		NULL 
	);
	// Process any inserts in lpMsgBuf.
	// ...
	// Display the string.
	OutputDebugString((LPTSTR)lpMsgBuf);
	MessageBox( NULL, (LPCTSTR)lpMsgBuf, L"Error", MB_OK | MB_ICONINFORMATION );
	// Free the buffer.
	LocalFree( lpMsgBuf );
}
