﻿//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.ResourceSystem
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceResources),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceResources
    {
        [PreserveSig]
        HResult GetSupportedResources(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        [PreserveSig]
        HResult GetResourceAttributes(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In] ref PropertyKey Key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResourceAttributes);

        [PreserveSig]
        HResult GetStream(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In] ref PropertyKey Key,
            [In] uint dwMode,
            [In, Out] ref uint pdwOptimalBufferSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppStream);

        [PreserveSig]
        HResult Delete(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys);

        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult CreateResource(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pResourceAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);
    }
}
