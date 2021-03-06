﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvokeIR.Win32
{
    class WinIoCtl
    {

        public const uint FILE_DEVICE_BEEP = 0x00000001;
        public const uint FILE_DEVICE_CD_ROM = 0x00000002;
        public const uint FILE_DEVICE_CD_ROM_FILE_SYSTEM = 0x00000003;
        public const uint FILE_DEVICE_CONTROLLER = 0x00000004;
        public const uint FILE_DEVICE_DATALINK = 0x00000005;
        public const uint FILE_DEVICE_DFS = 0x00000006;
        public const uint FILE_DEVICE_DISK = 0x00000007;
        public const uint FILE_DEVICE_DISK_FILE_SYSTEM = 0x00000008;
        public const uint FILE_DEVICE_FILE_SYSTEM = 0x00000009;
        public const uint FILE_DEVICE_INPORT_PORT = 0x0000000a;
        public const uint FILE_DEVICE_KEYBOARD = 0x0000000b;
        public const uint FILE_DEVICE_MAILSLOT = 0x0000000c;
        public const uint FILE_DEVICE_MIDI_IN = 0x0000000d;
        public const uint FILE_DEVICE_MIDI_OUT = 0x0000000e;
        public const uint FILE_DEVICE_MOUSE = 0x0000000f;
        public const uint FILE_DEVICE_MULTI_UNC_PROVIDER = 0x00000010;
        public const uint FILE_DEVICE_NAMED_PIPE = 0x00000011;
        public const uint FILE_DEVICE_NETWORK = 0x00000012;
        public const uint FILE_DEVICE_NETWORK_BROWSER = 0x00000013;
        public const uint FILE_DEVICE_NETWORK_FILE_SYSTEM = 0x00000014;
        public const uint FILE_DEVICE_NULL = 0x00000015;
        public const uint FILE_DEVICE_PARALLEL_PORT = 0x00000016;
        public const uint FILE_DEVICE_PHYSICAL_NETCARD = 0x00000017;
        public const uint FILE_DEVICE_PRINTER = 0x00000018;
        public const uint FILE_DEVICE_SCANNER = 0x00000019;
        public const uint FILE_DEVICE_SERIAL_MOUSE_PORT = 0x0000001a;
        public const uint FILE_DEVICE_SERIAL_PORT = 0x0000001b;
        public const uint FILE_DEVICE_SCREEN = 0x0000001c;
        public const uint FILE_DEVICE_SOUND = 0x0000001d;
        public const uint FILE_DEVICE_STREAMS = 0x0000001e;
        public const uint FILE_DEVICE_TAPE = 0x0000001f;
        public const uint FILE_DEVICE_TAPE_FILE_SYSTEM = 0x00000020;
        public const uint FILE_DEVICE_TRANSPORT = 0x00000021;
        public const uint FILE_DEVICE_UNKNOWN = 0x00000022;
        public const uint FILE_DEVICE_VIDEO = 0x00000023;
        public const uint FILE_DEVICE_VIRTUAL_DISK = 0x00000024;
        public const uint FILE_DEVICE_WAVE_IN = 0x00000025;
        public const uint FILE_DEVICE_WAVE_OUT = 0x00000026;
        public const uint FILE_DEVICE_8042_PORT = 0x00000027;
        public const uint FILE_DEVICE_NETWORK_REDIRECTOR = 0x00000028;
        public const uint FILE_DEVICE_BATTERY = 0x00000029;
        public const uint FILE_DEVICE_BUS_EXTENDER = 0x0000002a;
        public const uint FILE_DEVICE_MODEM = 0x0000002b;
        public const uint FILE_DEVICE_VDM = 0x0000002c;
        public const uint FILE_DEVICE_MASS_STORAGE = 0x0000002d;
        public const uint FILE_DEVICE_SMB = 0x0000002e;
        public const uint FILE_DEVICE_KS = 0x0000002f;
        public const uint FILE_DEVICE_CHANGER = 0x00000030;
        public const uint FILE_DEVICE_SMARTCARD = 0x00000031;
        public const uint FILE_DEVICE_ACPI = 0x00000032;
        public const uint FILE_DEVICE_DVD = 0x00000033;
        public const uint FILE_DEVICE_FULLSCREEN_VIDEO = 0x00000034;
        public const uint FILE_DEVICE_DFS_FILE_SYSTEM = 0x00000035;
        public const uint FILE_DEVICE_DFS_VOLUME = 0x00000036;
        public const uint FILE_DEVICE_SERENUM = 0x00000037;
        public const uint FILE_DEVICE_TERMSRV = 0x00000038;
        public const uint FILE_DEVICE_KSEC = 0x00000039;
        public const uint FILE_DEVICE_FIPS = 0x0000003A;
        public const uint FILE_DEVICE_INFINIBAND = 0x0000003B;
        public const uint FILE_DEVICE_VMBUS = 0x0000003E;
        public const uint FILE_DEVICE_CRYPT_PROVIDER = 0x0000003F;
        public const uint FILE_DEVICE_WPD = 0x00000040;
        public const uint FILE_DEVICE_BLUETOOTH = 0x00000041;
        public const uint FILE_DEVICE_MT_COMPOSITE = 0x00000042;
        public const uint FILE_DEVICE_MT_TRANSPORT = 0x00000043;
        public const uint FILE_DEVICE_BIOMETRIC = 0x00000044;
        public const uint FILE_DEVICE_PMI = 0x00000045;

        public const uint METHOD_BUFFERED = 0;
        public const uint METHOD_IN_DIRECT = 1;
        public const uint METHOD_OUT_DIRECT = 2;
        public const uint METHOD_NEITHER = 3;

        public const uint FILE_ANY_ACCESS = 0;
        public const uint FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS;
        public const uint FILE_READ_ACCESS = 0x0001;
        public const uint FILE_WRITE_ACCESS = 0x0002;

        protected static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            return ((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method);
        }

        public const uint IOCTL_UNKNOWN_BASE = FILE_DEVICE_UNKNOWN;

        #region USNControlCodes

        public static uint FSCTL_ENUM_USN_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 44, METHOD_NEITHER, FILE_ANY_ACCESS); // MFT_ENUM_DATA,
        public static uint FSCTL_READ_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 46, METHOD_NEITHER, FILE_ANY_ACCESS); // READ_USN_JOURNAL_DATA, USN
        public static uint FSCTL_CREATE_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 57,  METHOD_NEITHER, FILE_ANY_ACCESS); // CREATE_USN_JOURNAL_DATA,
        public static uint FSCTL_READ_FILE_USN_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 58,  METHOD_NEITHER, FILE_ANY_ACCESS); // Read the Usn Record for a file
        public static uint FSCTL_WRITE_USN_CLOSE_RECORD = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 59,  METHOD_NEITHER, FILE_ANY_ACCESS); // Generate Close Usn Record
        public static uint FSCTL_QUERY_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 61, METHOD_BUFFERED, FILE_ANY_ACCESS);
        public static uint FSCTL_DELETE_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 62, METHOD_BUFFERED, FILE_ANY_ACCESS);

        #endregion USNControlCodes

        public static uint FSCTL_GET_NTFS_VOLUME_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS); // NTFS_VOLUME_DATA_BUFFER
        
        //public const uint NTFS_VOLUME_DATA_BUFFER = 0x00090064;

    }
}
