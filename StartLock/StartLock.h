//StartLock.h

#ifndef _StartLock_H_
#define _StartLock_H_ 

#ifdef __cplusplus
	extern "C" {
#endif
	__declspec( dllexport ) void __stdcall LockStartMenu()

	__declspec( dllexport ) void __stdcall UnlockStartMenu()

	__declspec( dllexport ) void __stdcall LockStartBar()

	__declspec( dllexport ) void __stdcall UnlockStartBar()

	__declspec( dllexport ) bool __stdcall Lockdown(TCHAR *windowText)

	__declspec( dllexport ) bool __stdcall Unlockdown()

#ifdef __cplusplus
	}
#endif
#endif // _StartLock_H_ 
