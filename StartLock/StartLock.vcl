<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: StartLock - Win32 (WCE ARMV4I) Release--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "G:\Temp\RSPC5.tmp" with contents
[
/nologo /W3 /D _WIN32_WCE=500 /D "ARM" /D "_ARM_" /D "WCE_PLATFORM_CK60Prem" /D "ARMV4I" /D UNDER_CE=500 /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_USRDLL" /D "StartLock_EXPORTS" /FR"ARMV4IRel/" /Fp"ARMV4IRel/StartLock.pch" /Yu"stdafx.h" /Fo"ARMV4IRel/" /QRarch4T /QRinterwork-return /O2 /MC /c 
"D:\C-Source\Active\StartLock\StartLock.cpp"
]
Creating command line "clarm.exe @G:\Temp\RSPC5.tmp" 
Creating temporary file "G:\Temp\RSPC6.tmp" with contents
[
commctrl.lib coredll.lib /nologo /base:"0x00100000" /stack:0x10000,0x1000 /entry:"_DllMainCRTStartup" /dll /incremental:no /pdb:"ARMV4IRel/StartLock.pdb" /nodefaultlib:"libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib" /def:".\StartLock.def" /out:"ARMV4IRel/StartLock.dll" /implib:"ARMV4IRel/StartLock.lib" /subsystem:windowsce,5.00 /MACHINE:THUMB 
".\ARMV4IRel\StartLock.obj"
".\ARMV4IRel\StdAfx.obj"
".\ARMV4IRel\winfind.obj"
]
Creating command line "link.exe @G:\Temp\RSPC6.tmp"
<h3>Output Window</h3>
Compiling...
StartLock.cpp
Linking...
   Creating library ARMV4IRel/StartLock.lib and object ARMV4IRel/StartLock.exp
Creating command line "bscmake.exe /nologo /o"ARMV4IRel/StartLock.bsc"  ".\ARMV4IRel\StdAfx.sbr" ".\ARMV4IRel\StartLock.sbr" ".\ARMV4IRel\winfind.sbr""
Creating browse info file...
<h3>Output Window</h3>




<h3>Results</h3>
StartLock.dll - 0 error(s), 0 warning(s)
</pre>
</body>
</html>
