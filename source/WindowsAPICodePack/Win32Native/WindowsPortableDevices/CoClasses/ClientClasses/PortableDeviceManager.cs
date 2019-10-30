﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CoClasses.ClientClasses
{
    [ComImport,
        Guid(WPDCOMGuids.PortableDeviceManager),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceManager : IPortableDeviceManager
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult RefreshDeviceList();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult GetDeviceFriendlyName([ In, MarshalAs(UnmanagedType.LPWStr)]  string pszPnPDeviceID, [ In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName, [In,Out] ref uint pcchDeviceFriendlyName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult GetDeviceDescription([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription, ref uint pcchDeviceDescription);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult GetDeviceManufacturer([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer, ref uint pcchDeviceManufacturer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult GetDeviceProperty([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref string pszDevicePropertyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pData, ref uint pcbData, ref uint pdwType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern HResult GetPrivateDevices([MarshalAs(UnmanagedType.LPWStr)] string pPnPDeviceIDs, ref uint pcPnPDeviceIDs);
    }
}
