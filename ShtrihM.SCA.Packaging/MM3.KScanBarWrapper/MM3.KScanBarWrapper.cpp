// MM3.KScanBarWrapper.cpp : Defines the entry point for the DLL application.
//

#pragma once
#include "stdafx.h"
#include <windows.h>
#include "KScanBar.h"



BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    return TRUE;
}


typedef struct _MC1DBarCodeType
{	
	// 1D BarCode 18
	BOOL bCodabar;
	BOOL bCode11;
	BOOL bCode39;
	BOOL bCode93;
	BOOL bCode128;
	BOOL bGs1_128;
	BOOL bUpca;
	BOOL bUpce;
	BOOL bUpce1;
	BOOL bEan8;
	BOOL bEan13;
	BOOL bGs1;
	BOOL bI2of5;
	BOOL bMatrix2of5;
	BOOL bMsi;
	BOOL bPlessey;
	BOOL bStandard2of5;
	BOOL bTelepen;

}MC1DBarCodeType,* P1DBarCodeType;

typedef struct _MC2DBarCodeType
{	
	//2D BarCode 14
	BOOL bBpo;
	BOOL bDatamatrix;
	BOOL bMaxicode;
	BOOL bPdf417;
	BOOL bMicroPdf417;
	BOOL bPlanet;
	BOOL bQrCode;
	BOOL bTlc39;
	BOOL bPostnet;
	BOOL bAusPost;
	BOOL bCanadaPost;
	BOOL bDutchPost;
	BOOL bJapanPost;
	BOOL bSwedenPost;
}MC2DBarCodeType,* P2DBarCodeType;


  //CReg	m_Reg;
	DWORD	m_nDisplayType;
	BOOL	m_bKeyFlag;
	BOOL	m_bReading;
	BOOL	m_bBeep;
	DWORD	m_nSyncMode;
	DWORD	m_nTimeOut;
	DWORD	m_nSecurityLevel;
	BOOL	m_bXCD;
	BOOL	m_bCenterDecode;
	BOOL	m_b1DDecode;	

	MC1DBarCodeType m_1DBarCode;
	MC2DBarCodeType m_2DBarCode;
	


extern "C" 
{    
    typedef void  (*OnScanData) (int type, char * data); 
    OnScanData ScanCallback;
    KSCANREAD	kRead;
    KSCANREADEX kReadEx;
    
    int KSCANAPI KScanReadCallBack(LPVOID pRead)
    {	    
	    if(ScanCallback != NULL)
	    {
	      ScanCallback(((PKSCANREAD)pRead)->out_Type, ((PKSCANREAD)pRead)->out_Barcode);
	    }
	    return TRUE;
    }
  
    _declspec(dllexport) BOOL ScanInit(OnScanData callback)
    {
        BOOL bRet = KScanOpen(6, FALSE,	57600,	FALSE, NULL);
	      if(bRet == FALSE)
	      {
	        KScanClose();
		      Sleep(100);
	      }
	      else
	      {
          m_nTimeOut			= 2;
	        m_nSecurityLevel	= 1;

	        // Option
	        m_nSyncMode		= 0;
	        m_bXCD			= 1;
	        m_bBeep			= FALSE;
	        m_bCenterDecode	= 0;
	        m_b1DDecode		= 0;

	        // 1D BarCode 18
	        m_1DBarCode.bCodabar		= FALSE;
	        m_1DBarCode.bCode11			= FALSE;
	        m_1DBarCode.bCode39			= TRUE;
	        m_1DBarCode.bCode93			= FALSE;
	        m_1DBarCode.bCode128		= TRUE;
	        m_1DBarCode.bGs1_128		= TRUE;
	        m_1DBarCode.bUpca			= TRUE;
	        m_1DBarCode.bUpce			= TRUE;
	        m_1DBarCode.bUpce1			= FALSE;
	        m_1DBarCode.bEan8			= TRUE;
	        m_1DBarCode.bEan13			= TRUE;
	        m_1DBarCode.bGs1			= FALSE;
	        m_1DBarCode.bI2of5			= FALSE;
	        m_1DBarCode.bMatrix2of5		= FALSE;
	        m_1DBarCode.bMsi			= FALSE;
	        m_1DBarCode.bPlessey		= FALSE;
	        m_1DBarCode.bStandard2of5	= FALSE;
	        m_1DBarCode.bTelepen		= FALSE;
        	
	        // 2D BarCode 14
	        m_2DBarCode.bBpo			= FALSE;
	        m_2DBarCode.bDatamatrix		= TRUE;
	        m_2DBarCode.bMaxicode		= FALSE;
	        m_2DBarCode.bPdf417			= TRUE;
	        m_2DBarCode.bMicroPdf417	= FALSE;
	        m_2DBarCode.bPlanet			= FALSE;
	        m_2DBarCode.bQrCode			= FALSE;
	        m_2DBarCode.bTlc39			= FALSE;
	        m_2DBarCode.bPostnet		= FALSE;
	        m_2DBarCode.bAusPost		= FALSE;
	        m_2DBarCode.bCanadaPost		= FALSE;
	        m_2DBarCode.bDutchPost		= FALSE;
	        m_2DBarCode.bJapanPost		= FALSE;
	        m_2DBarCode.bSwedenPost		= FALSE;
        

	        memset(&kRead, 0, sizeof(kRead));						// initialization
	        kRead.nSize	= sizeof(kRead);				// initialization

	        // KScanReadCallBack
	        //kRead.pUserData = this;	
	        kRead.fnCallBack = KScanReadCallBack;

	        // ReadOption
	        kRead.nTimeInSeconds	= m_nTimeOut;		
	        kRead.nSecurity			= m_nSecurityLevel; 

	        // Option
	        if(m_bXCD == TRUE)
		        kRead.dwFlags |= KSCAN_FLAG_RETURNCHECK;
	        if(m_bCenterDecode == TRUE)
		        kRead.dwFlags |= KSCAN_FLAG_CENTERDECODE;
	        if(m_b1DDecode == TRUE)
		        kRead.dwFlags |= KSCAN_FLAG_1DDECODEMODE;

	        // 1D BarCode 18
	        if(m_1DBarCode.bCodabar)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CODABAR;
	        if(m_1DBarCode.bCode11)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CODE11;
	        if(m_1DBarCode.bCode39)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CODE39;
	        if(m_1DBarCode.bCode93)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CODE93;
	        if(m_1DBarCode.bCode128)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CODE128;
	        if(m_1DBarCode.bGs1_128)
		        kRead.dwReadType |= KSCAN_READ_TYPE_GS1_128;
	        if(m_1DBarCode.bUpca)
		        kRead.dwReadType |= KSCAN_READ_TYPE_UPCA;
	        if(m_1DBarCode.bUpce)
		        kRead.dwReadType |= KSCAN_READ_TYPE_UPCE;
	        if(m_1DBarCode.bUpce1)
		        kRead.dwReadType |= KSCAN_READ_TYPE_UPCE1;
	        if(m_1DBarCode.bEan8)
		        kRead.dwReadType |= KSCAN_READ_TYPE_EAN8;
	        if(m_1DBarCode.bEan13)
		        kRead.dwReadType |= KSCAN_READ_TYPE_EAN13;
	        if(m_1DBarCode.bGs1)
		        kRead.dwReadType |= KSCAN_READ_TYPE_GS1;
	        if(m_1DBarCode.bI2of5)
		        kRead.dwReadType |= KSCAN_READ_TYPE_I2OF5;
	        if(m_1DBarCode.bMatrix2of5)
		        kRead.dwReadType |= KSCAN_READ_TYPE_MATRIX2OF5;
	        if(m_1DBarCode.bMsi)
		        kRead.dwReadType |= KSCAN_READ_TYPE_MSI;
	        if(m_1DBarCode.bPlessey)
		        kRead.dwReadType |= KSCAN_READ_TYPE_PLESSEY;
	        if(m_1DBarCode.bStandard2of5)
		        kRead.dwReadType |= KSCAN_READ_TYPE_STANDARD2OF5;
	        if(m_1DBarCode.bTelepen)
		        kRead.dwReadType |= KSCAN_READ_TYPE_TELEPEN;

	        // 2D BarCode 14
	        if(m_2DBarCode.bBpo)
		        kRead.dwReadType |= KSCAN_READ_TYPE_BPO;
	        if(m_2DBarCode.bDatamatrix)
		        kRead.dwReadType |= KSCAN_READ_TYPE_DATAMATRIX;
	        if(m_2DBarCode.bMaxicode)
		        kRead.dwReadType |= KSCAN_READ_TYPE_MAXICODE;
	        if(m_2DBarCode.bPdf417)
		        kRead.dwReadType |= KSCAN_READ_TYPE_PDF417;
	        if(m_2DBarCode.bMicroPdf417)
		        kRead.dwReadType |= KSCAN_READ_TYPE_MICROPDF417;
	        if(m_2DBarCode.bPlanet)
		        kRead.dwReadType |= KSCAN_READ_TYPE_PLANET;
	        if(m_2DBarCode.bQrCode)
		        kRead.dwReadType |= KSCAN_READ_TYPE_QRCODE;
	        if(m_2DBarCode.bTlc39)
		        kRead.dwReadType |= KSCAN_READ_TYPE_TLC39;
	        if(m_2DBarCode.bPostnet)
		        kRead.dwReadType |= KSCAN_READ_TYPE_POSTNET;
	        if(m_2DBarCode.bAusPost)
		        kRead.dwReadType |= KSCAN_READ_TYPE_AUSPOST;
	        if(m_2DBarCode.bCanadaPost)
		        kRead.dwReadType |= KSCAN_READ_TYPE_CANADAPOST;
	        if(m_2DBarCode.bDutchPost)
		        kRead.dwReadType |= KSCAN_READ_TYPE_DUTCHPOST;
	        if(m_2DBarCode.bJapanPost)
		        kRead.dwReadType |= KSCAN_READ_TYPE_JAPANPOST;
	        if(m_2DBarCode.bSwedenPost)
		        kRead.dwReadType |= KSCAN_READ_TYPE_SWEDENPOST;
        	
	        kRead.dwReadType = KSCAN_READ_TYPE_ALL;
        	

	        SetOption(&kRead);
	        SetReturn(1, *KScanReadCallBack);
  	      
	        //set an extern callback function 
          ScanCallback = callback;
        }
        return bRet;
    }
    
    _declspec(dllexport) void ScanCancel()
    {
      KScanReadCancel();
    }
    
    _declspec(dllexport) void ScanRead()
    {
      KScanRead();
    }
    
    _declspec(dllexport) void ScanClose()
    {
      KScanClose();
		  Sleep(100);
      ScanCallback = NULL;
    }
};
