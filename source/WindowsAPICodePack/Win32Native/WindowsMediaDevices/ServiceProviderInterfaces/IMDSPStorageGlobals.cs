﻿using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPStorageGlobals),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorageGlobals
    {
        HResult GetCapabilities(
            [Out] out uint pdwCapabilities);
        
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNum,
            [Out, In] ref StringBuilder abMac);
        
        HResult GetTotalSize(
            [Out] out uint pdwTotalSizeLow,
            [Out] out uint pdwTotalSizeHigh);
        
        HResult GetTotalFree(
            [Out] out uint pdwFreeLow,
            [Out] out uint pdwFreeHigh);
        
        HResult GetTotalBad(
            [Out] out uint pdwBadLow,
            [Out] out uint pdwBadHigh);
        
        HResult GetStatus(
            [Out] out uint pdwStatus);
        
        HResult Initialize(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress);
        
        HResult GetDevice(
            [Out] out IMDSPDevice ppDevice);
        
        HResult GetRootStorage(
            [Out] out IMDSPStorage ppRoot);
    }
}
