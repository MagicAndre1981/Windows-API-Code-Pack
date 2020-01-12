﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Events
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceEventCallback),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceEventCallback
    {
        HResult OnEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pEventParameters);
    }
}
