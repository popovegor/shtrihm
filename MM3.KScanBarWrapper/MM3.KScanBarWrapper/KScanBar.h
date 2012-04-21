/*============================================================================
//  KoamTac Scan Module SDK Include File
//
//  (C) Copyright KoamTac, Inc. 2004
//  http://barcode.koamtac.com/
//
//  Title:   KScanBar.h
//  Version: 3.20
//  Date:    February 1, 2005
//----------------------------------------------------------------------------
//  Change log:
//  DATE        REV  DESCRIPTION
//  ----------- ---- ---------------------------------------------------------
//  Feb 16 2004 1.45 Created
//  Mar 30 2004 2.07 Preliminary Release
//============================================================================
*/

#if !defined(__API_KSCANBAR_H__)
#define __API_KSCANBAR_H__

#ifdef __cplusplus
extern "C" {
#endif
//#pragma comment(lib, "KScanBar.lib")

#if !defined( PASCAL )
#define PASCAL  __pascal
#endif
#if !defined( WINAPI )
#define WINAPI	PASCAL
#endif
#if !defined( KSCANAPI )
#define KSCANAPI	WINAPI
#endif
#define KSCAN_API __declspec(dllimport)

typedef int (KSCANAPI * KS_FN_CALLBACK)(LPVOID);

typedef struct tagKSCANREAD {
	int             nSize;
	unsigned        nTimeInSeconds;
	unsigned long   dwFlags;
	unsigned long   dwReadType;
	int             nMinLength;
	int             nSecurity;
	KS_FN_CALLBACK  fnCallBack;
	LPVOID          pUserData;
	LPVOID          pReadEx;
	int             out_Status;
	int             out_Type;
	char            out_Barcode[2711];
} KSCANREAD;
typedef KSCANREAD *	PKSCANREAD;

typedef struct tagKSCANREADEX {
	int    nI2of5MinLength;
	int    nI2of5MaxLength;

	int    nCodabarMinLength;
	int    nCodabarMaxLength;

	HWND   hwnd;
	DWORD  UserMsg;
} KSCANREADEX;

#define RETURN_MESSAGE				0
#define RETURN_CALLBACK				1
#define RETURN_KEYMSG				2

#define WM_SCANDATA					  WM_APP + 350

// 1D BarCode 18
#define KSCAN_READ_TYPE_CODABAR			0x00000001L
#define KSCAN_READ_TYPE_CODE11			0x00000002L
#define KSCAN_READ_TYPE_CODE39			0x00000004L
#define KSCAN_READ_TYPE_CODE93			0x00000008L
#define KSCAN_READ_TYPE_CODE128			0x00000010L
#define KSCAN_READ_TYPE_GS1_128			0x00000020L
#define KSCAN_READ_TYPE_UPCA			0x00000040L
#define KSCAN_READ_TYPE_UPCE			0x00000080L
#define KSCAN_READ_TYPE_UPCE1			0x00000100L
#define KSCAN_READ_TYPE_EAN8			0x00000200L
#define KSCAN_READ_TYPE_EAN13			0x00000400L
#define KSCAN_READ_TYPE_GS1				0x00000800L
#define KSCAN_READ_TYPE_I2OF5			0x00001000L
#define KSCAN_READ_TYPE_MATRIX2OF5		0x00002000L
#define KSCAN_READ_TYPE_MSI				0x00004000L
#define KSCAN_READ_TYPE_PLESSEY			0x00008000L
#define KSCAN_READ_TYPE_STANDARD2OF5	0x00010000L
#define KSCAN_READ_TYPE_TELEPEN			0x00020000L

// 2D BarCode 14
#define KSCAN_READ_TYPE_BPO				0x00040000L
#define KSCAN_READ_TYPE_DATAMATRIX		0x00080000L
#define KSCAN_READ_TYPE_MAXICODE		0x00100000L
#define KSCAN_READ_TYPE_PDF417			0x00200000L
#define KSCAN_READ_TYPE_MICROPDF417		0x00400000L
#define KSCAN_READ_TYPE_PLANET			0x00800000L
#define KSCAN_READ_TYPE_QRCODE			0x01000000L
#define KSCAN_READ_TYPE_TLC39			0x02000000L
#define KSCAN_READ_TYPE_POSTNET			0x04000000L
#define KSCAN_READ_TYPE_AUSPOST			0x08000000L
#define KSCAN_READ_TYPE_CANADAPOST		0x10000000L
#define KSCAN_READ_TYPE_DUTCHPOST		0x20000000L
#define KSCAN_READ_TYPE_JAPANPOST		0x40000000L
#define KSCAN_READ_TYPE_SWEDENPOST		0x80000000L

#define KSCAN_READ_TYPE_ALL				0xFFFFFFFFL


// Protocol.cpp의 GetScanDataType()과 일치해야 함
#define KSCAN_RET_TYPE_CODABAR			0	
#define KSCAN_RET_TYPE_CODABLOCK_A		1	
#define KSCAN_RET_TYPE_CODABLOCK_F		2	
#define KSCAN_RET_TYPE_CODE11			3	
#define KSCAN_RET_TYPE_CODE39			4	
#define KSCAN_RET_TYPE_CODE93			5	
#define KSCAN_RET_TYPE_CODE128			6	
#define KSCAN_RET_TYPE_GS1_128			7	
#define KSCAN_RET_TYPE_DATAMATRIX		8	
#define KSCAN_RET_TYPE_UPCA				9
#define KSCAN_RET_TYPE_UPCE				10
#define KSCAN_RET_TYPE_EAN8				11
#define KSCAN_RET_TYPE_EAN13			12
#define KSCAN_RET_TYPE_UPCE1			13
#define KSCAN_RET_TYPE_ISXN				14
#define KSCAN_RET_TYPE_GS1				15
#define KSCAN_RET_TYPE_GS1_LIMITED		16
#define KSCAN_RET_TYPE_GS1_EXPANDED		17
#define KSCAN_RET_TYPE_I2OF5			18
#define KSCAN_RET_TYPE_MATRIX2OF5		19
#define KSCAN_RET_TYPE_MAXICODE			20	
#define KSCAN_RET_TYPE_MSI				21
#define KSCAN_RET_TYPE_PDF417			22
#define KSCAN_RET_TYPE_MICRO_PDF417 	23
#define KSCAN_RET_TYPE_PLANET			24
#define KSCAN_RET_TYPE_PLESSEY			25
#define KSCAN_RET_TYPE_QRCODE			26
#define KSCAN_RET_TYPE_STANDARD2OF5		27
#define KSCAN_RET_TYPE_TELEPEN			28
#define KSCAN_RET_TYPE_TLC39			29
#define KSCAN_RET_TYPE_POSTNET			30
#define KSCAN_RET_TYPE_AUSPOST			31
#define KSCAN_RET_TYPE_CANADAPOST		32
#define KSCAN_RET_TYPE_DUTCHPOST		33
#define KSCAN_RET_TYPE_JAPANPOST		34
#define KSCAN_RET_TYPE_SWEDENPOST		35
#define KSCAN_RET_TYPE_AZTEC			36
#define KSCAN_RET_TYPE_BPO				37
#define KSCAN_RET_TYPE_CC_AB			38
#define KSCAN_RET_TYPE_CC_C				39
#define KSCAN_RET_TYPE_INFOMAIL			40

#define KSCAN_RET_TYPE_UNKNOWN				0xFF

//
// Flags - Scanner parameters & UPC/EAN options
//
#define KSCAN_FLAG_REVERSEDIRECTION     0x00000010
#define KSCAN_FLAG_RETURNCHECK          0x00001000 // More fine-grained control is available in Decoder 6.04 (see below)
#define KSCAN_FLAG_ERRORCHECK           0x00002000 // More fine-grained control is available in Decoder 6.04 (see below)
#define KSCAN_FLAG_WIDESCANANGLE        0x00004000
#define KSCAN_FLAG_HIGHFILTERMODE       0x00008000
#define KSCAN_FLAG_CENTERDECODE			0x00010000	// Center Decode
#define KSCAN_FLAG_1DDECODEMODE			0x00000002	// 1D Decode Mode
//
// Only available in Decoder 6.00 or later
//
#define KSCAN_FLAG_UPCE_AS_UPCA         0x00000200 
#define KSCAN_FLAG_EAN8_AS_EAN13        0x00000400
#define KSCAN_FLAG_UPCE_AS_EAN13        0x00000800
#define KSCAN_FLAG_UPCA_AS_EAN13		0x00080000
//
// Only available in Decoder 6.04 or later
//
#define KSCAN_FLAG_VERIFYCHECK          0x00002000 // A name change only - same value as KSCAN_FLAG_ERRORCHECK
#define KSCAN_FLAG_I2OF5_VERIFYCHECK    0x00400000
#define KSCAN_FLAG_CODE39_VERIFYCHECK   0x00800000

#define KSCAN_FLAG_CODE39_FULLASCII     0x01000000 // kNotice : Added by ksw 2006.4.5

#define KSCAN_FLAG_CODABAR_NOSTARTSTOP  0x00000001

#define KSCAN_FLAG_I2OF5_RETURNCHECK	0x04000000
#define KSCAN_FLAG_CODE39_RETURNCHECK   0x08000000
#define KSCAN_FLAG_UPCE_RETURNCHECK     0x10000000
#define KSCAN_FLAG_UPCA_RETURNCHECK     0x20000000
#define KSCAN_FLAG_EAN8_RETURNCHECK     0x40000000
#define KSCAN_FLAG_EAN13_RETURNCHECK    0x80000000

//	KSCAN_FLAG_VERIFYCHECK 활성화 일때 아래 옵션 의미 있음. Default  : VERIFY10
#define KSCAN_FLAG_MSI_VERIFY10			0x00000002
#define KSCAN_FLAG_MSI_VERIFY11			0x00000004
#define KSCAN_FLAG_MSI_VERIFY1010		0x00000008
#define KSCAN_FLAG_MSI_VERIFY1110		0x00000020
/*
// Following flags are no longer used.
#define KSCAN_FLAG_PARTIALSOK           0x00000002	// No longer used.
#define KSCAN_FLAG_NOQUIETZONE          0x00000100	// No longer used.
#define KSCAN_FLAG_QUIET_START			0x00020000	// No longer used.
#define KSCAN_FLAG_QUIET_END			0x00040000	// No longer used.
*/

//
// PDF417 related constants that must be exposed top the application
//
const short KSCAN_CONST_PDF417_MIN_TILT = 2;
const short KSCAN_CONST_PDF417_MAX_TILT = 6;
const short KSCAN_CONST_PDF417_MAX_QUALITY = 4;
const short KSCAN_FLAG_START_SYMB_REQ = 1;
const short KSCAN_FLAG_STOP_SYMB_REQ  = 2;
const short KSCAN_FLAG_START_AND_STOP_SYMB_REQ = 3;
const short KSCAN_FLAG_START_OR_STOP_SYMB_REQ  = 4;
//
// Return values from Read
//
// Both blocking & non-blocking
#define KSCAN_RET_NORMAL                        0 // Barcode found
#define KSCAN_RET_USER_CANCEL                   2 // User initiated cancel of read operation
#define KSCAN_RET_TIMEOUT                       3 // Time-out: barcode not found
// Only for non-blocking
#define KSCAN_RET_BAR_NOTFOUND                  4 // Barcode not found till now
#define KSCAN_RET_NORMAL_SWEEP                  5 // Barcode found, but the security criteria has not been met
//
// Error codes (values are usually >= 10)
// DO NOT EXPLICITLY USE THESE CONSTANTS IN THE CODE AS THEY ARE LIKELY TO CHANGE.
// Call GetLastErrorMsg() to obtain the error messages.
//
#define KSCAN_RET_ERR_READ_ALREADYINPROGRESS   14
#define	KSCAN_RET_ERR_NOTHINGTOCANCEL          15
#define KSCAN_RET_ERR_READCANCEL_INPROGRESS    16

#define KSCAN_RET_ERR_COMM_NOTOPENED           20
#define KSCAN_RET_ERR_COMM_ALREADY_OPEN        21
#define KSCAN_RET_ERR_COMM_PORT_OUTOFRANGE     22
#define KSCAN_RET_ERR_COMM_PURGEFAILED         24
#define KSCAN_RET_ERR_COMM_CLOSEHANDLEFAILED   25
#define KSCAN_RET_ERR_COMM_SETCOMMSTATEFAILED  26
#define KSCAN_RET_ERR_COMM_READWRITEFAILED     27

#define KSCAN_RET_ERR_HW_NOTFOUND              30
#define KSCAN_RET_ERR_HW_RESPONSETIMEOUT       31
#define KSCAN_RET_ERR_HW_INVALIDRESP           32
#define KSCAN_RET_ERR_HW_CMDEXECUTIONFAILED    33
#define KSCAN_RET_ERR_THREAD_CREATIONFAILED    35
#define KSCAN_RET_ERR_EVENT_CREATION_FAILED    36
#define KSCAN_RET_ERR_READ_NOTTERMINATED       37

#define KSCAN_RET_ERR_SERIALNUMBER_READ_FAILED 40
#define KSCAN_RET_ERR_FWVERSION_READ_FAILED    41
#define KSCAN_RET_ERR_FWBUILD_READ_FAILED      42
#define KSCAN_RET_ERR_ALLVERSION_READ_FAILED   43
#define KSCAN_RET_ERR_SYMBOLOGY_READ_FAILED    44
#define KSCAN_RET_ERR_FW_TOO_OLD               45
#define KSCAN_RET_ERR_SCANNERTYPE_READ_FAILED  46

#define KSCAN_RET_ERR_PDF417_INSUFFICIENT_DATA 50

/*
// Following return values are no longer used.
#define KSCAN_RET_CHECKERROR                    1 // No longer used
#define KSCAN_RET_CHECKERROR_SWEEP              6 // No longer used
#define KSCAN_RET_ERR_UNKNOWN                  10 // No longer used
#define KSCAN_RET_ERR_DECODING                 11 // No longer used
#define KSCAN_RET_ERR_NOTSUPPORTED             12 // No longer used
#define KSCAN_RET_ERR_INVALID_FLAGS            13 // No longer used
#define KSCAN_RET_ERR_SWEEP_DATA               17 // No longer used
#define KSCAN_RET_ERR_COMM_CHKSUM              23 // No longer used
#define KSCAN_RET_ERR_HW_NOTSUPPORTED          34 // No longer used
*/


#ifdef __cplusplus
}
#endif


#define _C_INTERFACE


#if defined(_C_INTERFACE)

#ifdef __cplusplus
extern "C" {
#endif // __cplusplus

	KSCAN_API BOOL KSCANAPI KScanOpen(int CommNumber, BOOL CommDetect, DWORD BaudRate, BOOL BaudDetect, DWORD ExFlags);
	KSCAN_API BOOL KSCANAPI KScanClose();
	KSCAN_API void KSCANAPI SetOption(PKSCANREAD pRead);
	KSCAN_API void KSCANAPI SetReturn(int Type, KS_FN_CALLBACK fnCallBack);
	KSCAN_API BOOL KSCANAPI KScanRead();
	KSCAN_API BOOL KSCANAPI KScanReadCancel();
	KSCAN_API LPCTSTR KSCANAPI KScanSetBarCodeString(int nType);
	KSCAN_API LPCTSTR KSCANAPI KScanGetVersionInfo();

#ifdef __cplusplus
}
#endif // __cplusplus

#endif // defined(_C_INTERFACE)


#endif // !defined(__API_KSCANBAR_H__)
// End of file "KScanBar.h"
