//---------------------------------------------------------------------------
//   I N T E R M E C  T E C H N O L O G I E S  C O R P O R A T I O N
//   5 5 0  S E C O N D  S T R E E T
//   C E D A R  R A P I D S,  I O W A   U S A
//---------------------------------------------------------------------------
//   COPYRIGHT 2003 INTERMEC TECHNOLOGIES CORPORATION.
//   UNPUBLISHED - ALL RIGHTS RESERVED UNDER THE COPYRIGHT LAWS.
//   PROPRIETARY AND CONFIDENTIAL INFORMATION. DISTRIBUTION, USE
//   AND DISCLOSURE RESTRICTED BY INTERMEC TECHNOLOGIES CORPORATION.
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
//   FILE: WINFIND.cpp
//
//   DESC: Defines the signature capture routines
//---------------------------------------------------------------------------

#include "stdafx.h"
#include <stdlib.h>
#include <string.h>

#define MAX_BUFF_SIZE 256

HWND FindChildByName(HWND hWndTop, LPCTSTR lpWinName)
{
   HWND hWnd = GetWindow(hWndTop, GW_CHILD);
   for (int i=0; (i<100) && (hWnd!=0); i++)
   {
      TCHAR winText[MAX_BUFF_SIZE];
      int len = GetWindowText(hWnd, winText, MAX_BUFF_SIZE);

      if (_tcscmp(winText, lpWinName) == 0)
         return hWnd;

      hWnd = GetWindow(hWnd, GW_HWNDNEXT);
   }

   return 0;
}

//Callback function for locating a window by its caption.
LPCTSTR lpGlobalWinName;
BOOL CALLBACK FindTopWindowByName( HWND hWnd, LPARAM lParam )
{
   TCHAR winText[MAX_BUFF_SIZE];
   int len = GetWindowText(hWnd, winText, MAX_BUFF_SIZE);

   if (_tcscmp(winText, lpGlobalWinName) == 0)
   {
      *((HWND*)lParam) = hWnd;
      return FALSE; //Stop enumerating windows
   }
   else
   {
      HWND hWndChild = FindChildByName(hWnd, lpGlobalWinName);
      if (hWndChild != 0)
      {
         *((HWND*)lParam) = hWndChild;
         return FALSE; //Stop enumerating windows
      }
      else
         return TRUE;
   }
}

HWND FindWindowByName(LPCTSTR lpWinName)
{
   HWND hWnd = 0;
   lpGlobalWinName = lpWinName;        // must use global to pass string arg
   EnumWindows(FindTopWindowByName, (LPARAM)&hWnd);
   return hWnd;
}

HWND FindRootWindowByName(LPCTSTR lpWinName)
{
	HWND hWnd = FindWindowByName(lpWinName);
	if (hWnd != 0)
	{
		HWND hParent = hWnd;
		HWND hLastParent = 0;
		while (hParent != 0)
		{
			hLastParent = hParent;
			hParent = ::GetParent(hLastParent);
		}
		hWnd = hLastParent;
	}
	return hWnd;
}

HWND FindRootWindowByFocus()
{
	HWND hWnd = ::GetFocus();
	if (hWnd != 0)
	{
		HWND hParent = hWnd;
		HWND hLastParent = 0;
		while (hParent != 0)
		{
			hLastParent = hParent;
			hParent = ::GetParent(hLastParent);
		}
		hWnd = hLastParent;
	}
	return hWnd;
}