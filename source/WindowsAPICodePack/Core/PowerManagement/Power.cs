//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    internal static class Power
    {
        internal static PowerManagementNativeMethods.SystemPowerCapabilities
            GetSystemPowerCapabilities()
        {

            if (PowerManagementNativeMethods.CallNtPowerInformation(
              PowerManagementNativeMethods.PowerInformationLevel.SystemPowerCapabilities,
              IntPtr.Zero, 0, out PowerManagementNativeMethods.SystemPowerCapabilities powerCap,
              (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemPowerCapabilities))
              ) == CoreNativeMethods.StatusAccessDenied)

                throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessCapabilities);

            return powerCap;
        }

        internal static PowerManagementNativeMethods.SystemBatteryState GetSystemBatteryState()
        {

            if (PowerManagementNativeMethods.CallNtPowerInformation(
              PowerManagementNativeMethods.PowerInformationLevel.SystemBatteryState,
              IntPtr.Zero, 0, out PowerManagementNativeMethods.SystemBatteryState batteryState,
              (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemBatteryState))
              ) == CoreNativeMethods.StatusAccessDenied)

                throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessBatteryState);

            return batteryState;
        }

        /// <summary>
        /// Registers the application to receive power setting notifications 
        /// for the specific power setting event.
        /// </summary>
        /// <param name="handle">Handle indicating where the power setting 
        /// notifications are to be sent.</param>
        /// <param name="powerSetting">The GUID of the power setting for 
        /// which notifications are to be sent.</param>
        /// <returns>Returns a notification handle for unregistering 
        /// power notifications.</returns>
        internal static int RegisterPowerSettingNotification(
            IntPtr handle, Guid powerSetting) => PowerManagementNativeMethods.RegisterPowerSettingNotification(
                handle,
                ref powerSetting,
                0);
    }
}