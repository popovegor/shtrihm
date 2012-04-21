#ifndef _STARTLOCK_
#define _STARTLOCK_

//========================================================
// LockStartMenu()
//========================================================
#ifdef DYNAMIC_LOADING
	typedef void (*PFN_LockStartMenu)();
#else
	void LockStartMenu();
#endif

//========================================================
// UnlockStartMenu()
//========================================================
#ifdef DYNAMIC_LOADING
	typedef void (*PFN_UnlockStartMenu)();
#else
	void UnlockStartMenu();
#endif

//========================================================
// LockStartMenu2
//========================================================
#ifdef DYNAMIC_LOADING
	typedef void (*PFN_LockStartBar)();
#else
	void LockStartBar();
#endif

//========================================================
// UnlockStartMenu2
//========================================================
#ifdef DYNAMIC_LOADING
	typedef void (*PFN_UnlockStartBar)();
#else
	void UnlockStartBar();
#endif

//========================================================
// Lockdown
//========================================================
#ifdef DYNAMIC_LOADING
	typedef int (*PFN_Lockdown)(TCHAR *); 
#else
	bool Lockdown(TCHAR *windowText);
#endif

//========================================================
// Unlockdown
//========================================================
#ifdef DYNAMIC_LOADING
	typedef bool (*PFN_Unlockdown)();
#else
	bool Unlockdown();
#endif

#endif // _STARTLOCK_
