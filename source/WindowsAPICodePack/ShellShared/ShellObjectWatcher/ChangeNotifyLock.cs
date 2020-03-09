﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.Shell
{
    internal class ChangeNotifyLock
    {
        private readonly uint _event = 0;

        internal ChangeNotifyLock(Message message)
        {
            IntPtr lockId = ShellNativeMethods.SHChangeNotification_Lock(
                    message.WParam, (int)message.LParam, out IntPtr pidl, out _event);

            try
            {
                Trace.TraceInformation("Message: {0}", (ShellObjectChangeTypes)_event);

                ShellNotifyStruct notifyStruct = pidl.MarshalAs<ShellNotifyStruct>();

                var guid = new Guid(Win32Native.Guids.Shell.IShellItem2);

                if (notifyStruct.item1 != IntPtr.Zero &&
                    (((ShellObjectChangeTypes)_event) & ShellObjectChangeTypes.SystemImageUpdate) == ShellObjectChangeTypes.None)
                {

                    if (CoreErrorHelper.Succeeded(ShellNativeMethods.SHCreateItemFromIDList(
                        notifyStruct.item1, ref guid, out IShellItem2 nativeShellItem)))
                    {
                        _ = nativeShellItem.GetDisplayName(ShellItemDesignNameOptions.FileSystemPath,
                            out string name);
                        ItemName = name;

                        Trace.TraceInformation("Item1: {0}", ItemName);
                    }
                }
                else

                    ImageIndex = notifyStruct.item1.ToInt32();

                if (notifyStruct.item2 != IntPtr.Zero)

                    if (CoreErrorHelper.Succeeded(ShellNativeMethods.SHCreateItemFromIDList(
                        notifyStruct.item2, ref guid, out IShellItem2 nativeShellItem)))
                    {
                        _ = nativeShellItem.GetDisplayName(ShellItemDesignNameOptions.FileSystemPath,
                            out string name);
                        ItemName2 = name;

                        Trace.TraceInformation("Item2: {0}", ItemName2);
                    }
            }
            finally
            {
                if (lockId != IntPtr.Zero)

                    _ = ShellNativeMethods.SHChangeNotification_Unlock(lockId);
                            }

        }

        public bool FromSystemInterrupt => ((ShellObjectChangeTypes)_event & ShellObjectChangeTypes.FromInterrupt)
                    != ShellObjectChangeTypes.None;

        public int ImageIndex { get; private set; }
        public string ItemName { get; private set; }
        public string ItemName2 { get; private set; }

        public ShellObjectChangeTypes ChangeType => (ShellObjectChangeTypes)_event;


    }
}
