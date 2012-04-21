<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: TestStartLock - Win32 (WCE ARMV4I) Release--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "G:\Temp\RSP65.tmp" with contents
[
/nologo /W3 /D "ARM" /D "_ARM_" /D "ARMV4I" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_CK60Prem" /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_AFXDLL" /FR"ARMV4IRel/" /Fp"ARMV4IRel/TestStartLock.pch" /Yu"stdafx.h" /Fo"ARMV4IRel/" /QRarch4T /QRinterwork-return /O2 /MC /c 
"D:\C-Source\Active\StartLock\TestStartLockDLL\TestStartLockDlg.cpp"
]
Creating command line "clarm.exe @G:\Temp\RSP65.tmp" 
Creating temporary file "G:\Temp\RSP66.tmp" with contents
[
/nologo /base:"0x00010000" /stack:0x10000,0x1000 /entry:"wWinMainCRTStartup" /incremental:no /pdb:"ARMV4IRel/TestStartLock.pdb" /out:"ARMV4IRel/TestStartLock.exe" /subsystem:windowsce,5.00 /MACHINE:THUMB 
".\ARMV4IRel\StdAfx.obj"
".\ARMV4IRel\TestStartLock.obj"
".\ARMV4IRel\TestStartLockDlg.obj"
".\ARMV4IRel\TestStartLock.res"
]
Creating command line "link.exe @G:\Temp\RSP66.tmp"
<h3>Output Window</h3>
Compiling...
TestStartLockDlg.cpp
Linking...
Creating command line "bscmake.exe /nologo /o"ARMV4IRel/TestStartLock.bsc"  ".\ARMV4IRel\StdAfx.sbr" ".\ARMV4IRel\TestStartLock.sbr" ".\ARMV4IRel\TestStartLockDlg.sbr""
Creating browse info file...
<h3>Output Window</h3>




<h3>Results</h3>
TestStartLock.exe - 0 error(s), 0 warning(s)
</pre>
</body>
</html>
