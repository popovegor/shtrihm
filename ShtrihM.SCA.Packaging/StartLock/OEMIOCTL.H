#ifndef __OEMIOCTL_H__
#define __OEMIOCTL_H__

/* Copyright © 2000-2001 Intel Corp.  */
/*++

Module Name:  $Workfile: OEMIOCTL.H $

Abstract:  
 Contains definitions specific to Intel XScale 
 Microarchitecture OEMIOcontrol calls.
 
--*/

#include <winioctl.h>

#define OAL_VERSION "1.00"
#define CORE_OEM_IOCTL_BASE						0x800
#define PLATFORM_ITC_IOCTL_BASE					0x8B0
#define PLATFORM_OEM_IOCTL_BASE					0xC00
#define PLATFORM_PMU_IOCTL_BASE					0xFA0

//----------------------------------------------------------------------------
//
// These IOCTL codes allow the platform to be reset
//
//----------------------------------------------------------------------------

#define IOCTL_HAL_WARMBOOT		 				CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 4, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_COLDBOOT		 				CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 5, METHOD_BUFFERED, FILE_ANY_ACCESS)


//----------------------------------------------------------------------------
//
// These IOCTL codes allow CPU or companion chip GPIO bits to be manipulated
//
//----------------------------------------------------------------------------

typedef struct {
	DWORD Chip;		// in - chip: 0 = cpu on chip gpio, 1 = companion chip gpio
	DWORD Group;	// in - 0 = first gpio group supported by chip, 1 = second gpio group...
	DWORD Mask;		// in - bit mask for bits to be read or modified
	DWORD Value;	// in - write: value of bits to modify, out - read: value of bits read
} HAL_GPIO_STRUCT, * PHAL_GPIO_STRUCT;

//////////////////////////////////////////////////////////////////////////////
//
// gpio chip: 0 = cpu on chip gpio, 1 = companion chip gpio
// gpio group: 0 = first gpio group supported by chip, 1 = second gpio group...
// 
//////////////////////////////////////////////////////////////////////////////
//
// SA11x0:
//
//   gpio group 0 specifies the GP(27:0) pins, in the value and mask fields, bit 0 selects GP0, etc.
//
//   gpio group 1 specifies the pins that are controlled by the peripheral pin controller.
//     thes are pins that are available as gpio only if they are not used by the block they 
//     are normally associated with. The bit positions in the mask and value correspond to
//     the bits in the SA11x0 PPDR, PPSR and PSDR registers. See the SA11x0 developer's
//     manual for more information.
//
//     Bit      SA11x0 Pin
//     ---      ----------
//     bit0  -> LDD0
//     bit1  -> LDD1
//     ...      ...
//     bit7  -> LDD7
//     bit8  -> LPCLK
//     bit9  -> LLCLK
//     bit10 -> LFCLK
//     bit11 -> LBIAS
//     bit12 -> TXD1
//     bit13 -> RXD1
//     bit14 -> TXD2
//     bit15 -> RXD2
//     bit16 -> TXD3
//     bit17 -> RXD3
//     bit18 -> TXD4
//     bit19 -> RXD4
//     bit20 -> SCLK
//     bit21 -> SRFM
//
//////////////////////////////////////////////////////////////////////////////
#define IOCTL_HAL_GPIO_AF						CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GPIO_READ						CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 8, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GPIO_WRITE					CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 9, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GPIO_DIRECTION				CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 10, METHOD_BUFFERED, FILE_ANY_ACCESS)

//----------------------------------------------------------------------------
//
// These IOCTL codes allow access to custom registers
//
//----------------------------------------------------------------------------

typedef struct {
	DWORD Register;		// in - register number
	DWORD Mask;			// in - mask of bits to read or modify
	DWORD Value;		// in - write: value of bits to modify, out - read: value of bits read
} HAL_CUSTOM_REGISTER_STRUCT, * PHAL_CUSTOM_REGISTER_STRUCT;

#define IOCTL_HAL_CUSTOM_READ_BITFIELD			CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 11, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_CUSTOM_WRITE_BITFIELD			CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 12, METHOD_BUFFERED, FILE_ANY_ACCESS)

// searay custom board registers 
#define CUSTOM_REG_BCR			0
#define CUSTOM_REG_HCR0			1
#define CUSTOM_REG_HCR1			2
#define CUSTOM_REG_FPGA200		3
#define CUSTOM_REG_FPGA600		4

//other controls

#define IOCTL_HAL_GET_RESET_INFO CTL_CODE( FILE_DEVICE_HAL, 0x817, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GET_BOOT_DEVICE CTL_CODE( FILE_DEVICE_HAL, 0x816, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_TRANSLATE_KERNEL_TO_PHYSICAL CTL_CODE( FILE_DEVICE_HAL, 0x807, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_TRANSLATE_PHYSICAL_TO_KERNEL CTL_CODE( FILE_DEVICE_HAL, 0x806, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GET_BOOTLOADER_VERINFO CTL_CODE( FILE_DEVICE_HAL, 0x801, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_GET_OAL_VERINFO CTL_CODE( FILE_DEVICE_HAL, 0x800, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define HAL_BOOT_DEVICE_UNKNOWN			0
#define HAL_BOOT_DEVICE_ROM_XIP			1
#define HAL_BOOT_DEVICE_ROM				2
#define HAL_BOOT_DEVICE_PCMCIA_ATA		3
#define HAL_BOOT_DEVICE_PCMCIA_LINEAR	4
#define HAL_BOOT_DEVICE_IDE_ATA			5
#define HAL_BOOT_DEVICE_IDE_ATAPI		6
#define HAL_BOOT_DEVICE_ETHERNET		7
#define HAL_BOOT_DEVICE_80211b			8
#define HAL_BOOT_DEVICE_SDMMC			9



#define HAL_RESET_TYPE_UNKNOWN			0
#define HAL_RESET_REASON_HARDWARE		1
#define HAL_RESET_REASON_SOFTWARE		2
#define HAL_RESET_REASON_WATCHDOG		4
#define HAL_RESET_BATT_FAULT			8
#define HAL_RESET_VDD_FAULT				16

#define HAL_OBJECT_STORE_STATE_UNKNOWN	0
#define HAL_OBJECT_STORE_STATE_CLEAR	1

typedef struct VersionInfo
{
	int				cboemverinfo;			// sizeof (tagOemVerInfo);
	unsigned short	verinfover;			// version number of version info structure
	char			sig[8];					// "ACCELVER" - Accelent Systems Signature
	char			id;						// 'B' = boot loader, 'N' = CE image
	char			tgtcustomer[24];		// _TGTCUSTOMER -    customer name
	char			tgtplat[24];			// _TGTPLAT - 	     platform name
	char			tgtplatversion[8];		// _TGTPLATVERSION - platform version
	char			tgtcputype[8];			// _TGTCPUTYPE -     CPU type
	char			tgtcpu[12];				// _TGTCPU -         CPU name
	char			tgtcoreversion[8];		// _TGTCOREVERSION - ASI software core version
	char			date[12];				// __DATE__ -        build date
	char			time[12];				// __TIME__ -        build time

} VERSIONINFO, *PVERSIONINFO;
//----------------------------------------------------------------------------
//
// These IOCTL codes allow CODEC registers to be manipulated
//
//----------------------------------------------------------------------------

#define IOCTL_HAL_CODEC_REGISTER_MUTEX_NAME		CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 13, METHOD_BUFFERED, FILE_ANY_ACCESS)

typedef struct {
	DWORD Chip;			// in - use 0 for first CODEC (only one supported at this time)
	DWORD Register;		// in - register number
	DWORD Mask;			// in - mask of bits to read or modify for write (bits not included in mask will not be changed)
	DWORD Value;	// in - write: value of bits to modify, out - read: value of bits read
} HAL_CODEC_REGISTER_STRUCT, * PHAL_CODEC_REGISTER_STRUCT;

#define IOCTL_HAL_CODEC_REGISTER_READ			CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 14, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_CODEC_REGISTER_WRITE			CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 15, METHOD_BUFFERED, FILE_ANY_ACCESS)
//----------------------------------------------------------------------------
//
// Get Address of OEMIoControl function
//
// This IOCTL code allows a driver to get a kernel mode pointer to the
// OemIoControl() function. This function can be called directly from a driver's
// power handler function for custom hardware access during suspend/resume.
//
// The OemIoControl() function can process only the Kernel IOCTL codes
// defined in this file.
//
// The parameters to the OemIoControl() function are identical to the KernelIoControl()
// function parameters.
//
// The only Kernel IOCTL codes that should be called using the OemIoControl() pointer are:
//
// IOCTL_HAL_GPIO_READ, IOCTL_HAL_GPIO_WRITE, IOCTL_HAL_GPIO_DIRECTION
// IOCTL_HAL_CUSTOM_READ_BITFIELD, IOCTL_HAL_CUSTOM_WRITE_BITFIELD
// IOCTL_HAL_CODEC_REGISTER_READ, IOCTL_HAL_CODEC_REGISTER_WRITE
//
// The OemIoControl() function can only be called from kernel mode.
//
//----------------------------------------------------------------------------

// This is the type of the value returned in lpOutBuf for the IOCTL_HAL_GET_OEMIOCTL_ADDRESS function.
typedef BOOL (* POEMIOCONTROL)(
	DWORD dwIoControlCode,
	LPVOID lpInBuf,
	DWORD nInBufSize,
	LPVOID lpOutBuf,
	DWORD nOutBufSize,
	LPDWORD lpBytesReturned);

#define IOCTL_HAL_GET_OEMIOCONTROL_ADDRESS		CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 24, METHOD_BUFFERED, FILE_ANY_ACCESS)



#define ucSignature "B000FF\n"
  
#pragma pack (1)

typedef struct {
    BYTE Signature[sizeof(ucSignature)-1];
    DWORD StartAddress;
    DWORD Size;
} IMAGEHEADER;
 
typedef struct {
    DWORD Address;
    DWORD Size;
    DWORD Checksum;
} SECTIONHEADER;

typedef struct {
	DWORD ResetReason;		// type of the most recent reset
	DWORD ObjectStoreState;	// state of the object store
} HAL_RESET_INFO, * PHAL_RESET_INFO;


//
// Added OEMIOcontrol codes
//
#define IOCTL_PMU_CONFIG CTL_CODE(FILE_DEVICE_HAL, PLATFORM_PMU_IOCTL_BASE+0, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_GET_CPU_ID CTL_CODE(FILE_DEVICE_HAL, PLATFORM_PMU_IOCTL_BASE+1, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_PMU_CCF    CTL_CODE(FILE_DEVICE_HAL, PLATFORM_PMU_IOCTL_BASE+2, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_TURBO_MODE CTL_CODE(FILE_DEVICE_HAL, PLATFORM_PMU_IOCTL_BASE+3, METHOD_BUFFERED, FILE_ANY_ACCESS)

//
// Subcodes to IOCTL_PMU_CONFIG
//
#define PMU_ENABLE_IRQ	1
#define PMU_ENABLE_FIQ	2
#define PMU_DISABLE_IRQ 3
#define PMU_DISABLE_FIQ 4
#define PMU_READ_REG	5
#define PMU_WRITE_REG	6

//
// Subcodes to IOCTL_PMU_CCF
//
#define PMU_CCF_GETCURRENT      1
#define PMU_CCF_SETLOCK         2
#define PMU_CCF_UNLOCKRESTORE   3

//
// Subcodes to IOCTL_TURBO_MODE
//
#define PWR_ENTER_TURBO     1
#define PWR_EXIT_TURBO      2

//
// Struct for PMU Register access
//
typedef struct {
    unsigned long subcode;
    unsigned long PMUReg;
    unsigned long PMUValue;
} PMURegInfo, *PPMURegInfo;

//
// Struct for PMU CCF access
//
typedef struct {
    unsigned long subcode;
    unsigned long newFreq;
    unsigned long curFreq;
} PMUCCFInfo, *PPMUCCFInfo;

//
// Struct for TURBO MODE info
//
typedef struct {
    unsigned long subcode;
} PWRTurboInfo, *PPWRTurboInfo;

//
// Struct for CPU ID info
//
typedef struct {
    unsigned long CPUId;
} CPUIdInfo, *PCPUIdInfo;


#define IOCTL_HAL_NMSD_READ_PARM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 1, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_NMSD_WRITE_PARM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 2, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_NMSD_INIT_PARAM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 3, METHOD_BUFFERED, FILE_ANY_ACCESS)

// Norand standard parameter ID's
#define APM_PARM_ETHERNET_ID		1	// Ethernet ID 6 bytes + 1 byte CRC.
#define APM_PARM_ETHERNET_LTH		6	// Ethernet ID length
#define APM_PARM_MANF_DATE			3	// Manf date. BCD: yymmdd.
#define APM_PARM_PEN_ALIGN_ID 		19	// Pen alignment id: 8 bytes at the moment.
#define APM_PARM_PEN_ALIGN_LTH		8	// Pen alignment length

#define IOCTL_HAL_ITC_READ_PARM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 1, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_ITC_WRITE_PARM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 2, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_ITC_INIT_PARAM 	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 3, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define ITC_NVPARM_ETHERNET_ID		1	// Ethernet ID 6 bytes + 1 byte CRC.
#define ITC_NVPARM_SERIAL_NUM		2
#define ITC_NVPARM_MANF_DATE		3	// Manf date. BCD: yymmdd.
#define ITC_NVPARM_SERVICE_DATE		4
#define ITC_NVPARM_DISPLAY_TYPE		5
#define ITC_NVPARM_EDG_IP			6
#define ITC_NVPARM_EDBG_SUBNET		7
#define ITC_NVPARM_ECN				8
#define ITC_NVPARM_CONTRAST			9
#define ITC_NVPARM_MCODE			10
#define ITC_IRQS					11
#define ITC_REGISTRY_LOCATION		12
#define	ITC_REGISTRY_SAVE_ENABLE	13
#define ITC_NVPARM_VERSION_NUMBER	14

#define VN_CLASS_KBD				1
#define VN_CLASS_ASIC				2
#define VN_CLASS_BOOTSTRAP			3

#define IOCTL_HAL_OEM_POWER_INTERRUPT_DISABLE	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 18, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_OEM_POWER_INTERRUPT_ENABLE	CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 19, METHOD_BUFFERED, FILE_ANY_ACCESS)
#endif