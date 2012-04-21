// TestStartLockDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TestStartLock.h"
#include "TestStartLockDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//add some cool macros
#include "windowsx.h"

//=============================================================================

//#define DYNAMIC_LOADING

#include "StartLock.h"

#if !defined DYNAMIC_LOADING
	#ifdef _DEBUG_
		#pragma comment (lib, "../ARMV4iDbg/StartLock.lib")
	#else
		//#pragma comment (lib, "../ARMV4iRel/StartLock.lib")
	#endif //DEBUG
#endif

//=============================================================================
// load the functions
HINSTANCE hLib = NULL;

BOOL g_bStartmenuBlocked=FALSE;
BOOL g_bStartbarBlocked=FALSE;
BOOL g_bLockedDown=FALSE;

int LoadProcs()
{
#ifdef DYNAMIC_LOADING
	hLib = LoadLibrary(L"StartLock.dll");
	if (hLib == NULL)
	{
		AfxMessageBox(L"Could not load StartLock.dll");
		return -1;
	}
	else
	{
		//load the function pointers
		LockStartMenu = (PFN_LockStartMenu)GetProcAddress(hLib, _T("LockStartMenu"));
		UnlockStartMenu = (PFN_UnlockStartMenu)GetProcAddress(hLib, _T("UnlockStartMenu"));
		LockStartBar = (PFN_LockStartBar)GetProcAddress(hLib, _T("LockStartBar"));
		UnlockStartBar = (PFN_UnlockStartBar)GetProcAddress(hLib, _T("UnlockStartBar"));
		Lockdown = (PFN_Lockdown)GetProcAddress(hLib, _T("Lockdown"));
		Unlockdown = (PFN_Unlockdown)GetProcAddress(hLib, _T("Unlockdown"));
		if( (LockStartMenu!=NULL) & 
			(UnlockStartMenu!=NULL) & 
			(LockStartBar!=NULL) & 
			(UnlockStartBar!=NULL) & 
			(Lockdown!=NULL) & 
			(Unlockdown!=NULL) )

			return 0;
		else
			return -2;
	}
#else
	return 0;
#endif //DYNAMIC_LOADING
}

//=============================================================================


/////////////////////////////////////////////////////////////////////////////
// CTestStartLockDlg dialog

CTestStartLockDlg::CTestStartLockDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTestStartLockDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTestStartLockDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTestStartLockDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTestStartLockDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CTestStartLockDlg, CDialog)
	//{{AFX_MSG_MAP(CTestStartLockDlg)
	ON_BN_CLICKED(IDC_UNLOCKDOWN, OnUnlockdown)
	ON_BN_CLICKED(IDC_LOCKSTART, OnLockstart)
	ON_BN_CLICKED(IDC_UNLOCKSTART, OnUnlockstart)
	ON_BN_CLICKED(IDC_HOOK_ON, OnHookOn)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_UnlockBar, OnUnlockBar)
	ON_BN_CLICKED(IDC_LOCKDOWN, OnLockdown)
	ON_BN_CLICKED(IDC_BTN_LAUNCH, OnBtnLaunch)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTestStartLockDlg message handlers

BOOL CTestStartLockDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	CenterWindow(GetDesktopWindow());	// center to the hpc screen

	// TODO: Add extra initialization here
	if (LoadProcs()!=0)
	{
		AfxMessageBox(L"Error loading procs");
		PostQuitMessage(-1);
		return TRUE;
	}
	SetDlgItemText(IDC_DEVICEID, L"Lock Start Mneu or Bar, make FullScreen");

	return TRUE;  // return TRUE  unless you set the focus to a control
}



void CTestStartLockDlg::OnLockdown() 
{
	// TODO: Add your control notification handler code here
	// Get a handle to the 80211 API
	if(!g_bLockedDown){
		TCHAR wText[MAX_PATH];
		// Get the title bar text
		GetWindowText(wText, sizeof(wText) / sizeof(wText[0]));
		Lockdown(wText);
		setText(L"Window now FullScreen w/o StartBar"); 
		g_bLockedDown=TRUE;
	}
	else
		setText(L"Window already FullScreen"); 
}

void CTestStartLockDlg::OnUnlockdown() 
{
	if(g_bLockedDown){
		int rc = Unlockdown();
		if (!rc)
			setText(L"call to Unlockdown returned false");
		else
			setText(L"Window no more FullScreen StartBar is visible"); 
		g_bLockedDown=FALSE;
	}
	else
		setText(L"Window is not locked down"); 
}

void CTestStartLockDlg::OnLockstart() 
{
	// TODO: Add your control notification handler code here
	if (!g_bStartmenuBlocked){
		LockStartMenu(); //install hook
		setText(L"StartMenu blocked");
		g_bStartmenuBlocked=TRUE;
	}
	else
		setText(L"StartMenu already hooked");
}

void CTestStartLockDlg::OnUnlockstart() 
{
	// TODO: Add your control notification handler code here
	if (g_bStartmenuBlocked){
		UnlockStartMenu(); //uninstall hook
		setText(L"StartMenu unhooked");
		g_bStartmenuBlocked=FALSE;
	}
	else
		setText(L"StartMenu is already hooked");
}

void CTestStartLockDlg::OnHookOn() 
{
	// TODO: Add your control notification handler code here
	if(!g_bStartbarBlocked){
		LockStartBar();
		setText(L"StartBar blocked / disabled");
		g_bStartbarBlocked=TRUE;
	}
	else
		setText(L"StartBar is already blocked");
}

void CTestStartLockDlg::OnDestroy() 
{
	Unlockdown();
	UnlockStartMenu();
	UnlockStartBar();

#if !defined DYNAMIC_LOADING
	FreeLibrary(hLib);
#endif

	CDialog::OnDestroy();
	
	// TODO: Add your message handler code here
	
}

void CTestStartLockDlg::OnUnlockBar() 
{
	// TODO: Add your control notification handler code here
	if(g_bStartbarBlocked){
		UnlockStartBar();
		setText(L"StartBar unblocked");
		g_bStartbarBlocked=FALSE;
	}
	else
		setText(L"Startbar was not blocked");
}

void CTestStartLockDlg::setText(TCHAR *txt)
{
	SetDlgItemText(IDC_DEVICEID, txt);
}

void CTestStartLockDlg::OnBtnLaunch() 
{
	// TODO: Add your control notification handler code here
	PROCESS_INFORMATION pi;
	if( CreateProcess(L"\\Windows\\fexplore.exe", L"", NULL, NULL, FALSE, 0, NULL, NULL, NULL, &pi) ){
		setText(L"Started fexplore.exe");
		CloseHandle(pi.hThread);
		CloseHandle(pi.hProcess);
	}
	else
		setText(L"Starting fexplore.exe failed");
}
