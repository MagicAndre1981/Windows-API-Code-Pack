﻿//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native.Guids.Shell;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [ComImport,
    Guid(ShellIIDGuid.IShellLibrary),
    CoClass(typeof(ShellLibraryCoClass))]
    public interface INativeShellLibrary : IShellLibrary
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(ShellCLSIDGuid.ShellLibrary)]
    public class ShellLibraryCoClass
    {
    }
}
