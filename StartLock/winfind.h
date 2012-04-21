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
//   FILE: WINFIND.h
//
//   DESC: Defines the signature capture routines
//---------------------------------------------------------------------------

#include "stdafx.h"

HWND FindWindowByName(LPCTSTR lpWinName);
HWND FindRootWindowByName(LPCTSTR lpWinName);
HWND FindRootWindowByFocus();
