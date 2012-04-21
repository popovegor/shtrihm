// TestStartLock.h : main header file for the TestStartLock application
//

#if !defined(AFX_TestStartLock_H__CE1E5561_526B_4538_89B6_C6605AF7A932__INCLUDED_)
#define AFX_TestStartLock_H__CE1E5561_526B_4538_89B6_C6605AF7A932__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CTestStartLockApp:
// See TestStartLock.cpp for the implementation of this class
//

class CTestStartLockApp : public CWinApp
{
public:
	CTestStartLockApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestStartLockApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CTestStartLockApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TestStartLock_H__CE1E5561_526B_4538_89B6_C6605AF7A932__INCLUDED_)
