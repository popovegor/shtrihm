// TestStartLockDlg.h : header file
//

#if !defined(AFX_TestStartLockDLG_H__52B3E231_F853_4950_BA6E_53635F288FE9__INCLUDED_)
#define AFX_TestStartLockDLG_H__52B3E231_F853_4950_BA6E_53635F288FE9__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000


/////////////////////////////////////////////////////////////////////////////
// CTestStartLockDlg dialog

class CTestStartLockDlg : public CDialog
{
// Construction
public:
	void setText(TCHAR* txt);
	CTestStartLockDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CTestStartLockDlg)
	enum { IDD = IDD_TestStartLock_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestStartLockDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CTestStartLockDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnUnlockdown();
	afx_msg void OnLockstart();
	afx_msg void OnUnlockstart();
	afx_msg void OnHookOn();
	afx_msg void OnDestroy();
	afx_msg void OnUnlockBar();
	afx_msg void OnLockdown();
	afx_msg void OnBtnLaunch();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TestStartLockDLG_H__52B3E231_F853_4950_BA6E_53635F288FE9__INCLUDED_)
