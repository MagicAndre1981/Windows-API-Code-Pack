﻿using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using Message = Microsoft.WindowsAPICodePack.Win32Native.Shell.Message;

namespace Microsoft.WindowsAPICodePack.COMNative.ShellExtensions
{
    #region Interfaces

    /// <summary>
    /// ComVisible interface for native IThumbnailProvider
    /// </summary>
    [ComImport]
    [Guid(NativeAPI.Guids.ShellExtensions.IThumbnailProvider)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IThumbnailProvider
    {
        ///// <summary>
        ///// Gets a pointer to a bitmap to display as a thumbnail
        ///// </summary>
        ///// <param name="squareLength"></param>
        ///// <param name="bitmapHandle"></param>
        ///// <param name="bitmapType"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        void GetThumbnail(uint squareLength, [Out] out IntPtr bitmapHandle, [Out] out uint bitmapType);
    }

    /// <summary>
    /// Provides means by which to initialize with a file.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.ShellExtensions.IInitializeWithFile)]
    public interface IInitializeWithFile
    {
        ///// <summary>
        ///// Initializes with a file.
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <param name="fileMode"></param>
        void Initialize([MarshalAs(UnmanagedType.LPWStr)] string filePath, AccessModes fileMode);
    }

    /// <summary>
    /// Provides means by which to initialize with a stream.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    [ComImport]
    [Guid(NativeAPI.Guids.ShellExtensions.IInitializeWithStream)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithStream
    {
        ///// <summary>
        ///// Initializes with a stream.
        ///// </summary>
        ///// <param name="stream"></param>
        ///// <param name="fileMode"></param>
        void Initialize(IStream stream, AccessModes fileMode);
    }

    /// <summary>
    /// Provides means by which to initialize with a ShellObject
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.ShellExtensions.IInitializeWithItem)]
    public interface IInitializeWithItem
    {
        ///// <summary>
        ///// Initializes with ShellItem
        ///// </summary>
        ///// <param name="shellItem"></param>
        ///// <param name="accessMode"></param>
        void Initialize(IShellItem shellItem, AccessModes accessMode);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.COM.IObjectWithSite)]
    public interface IObjectWithSite
    {
        void SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkSite);
        void GetSite(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvSite);
    }

    [ComImport]
    [Guid(NativeAPI.Guids.COM.IOleWindow)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleWindow
    {
        void GetWindow(out IntPtr phwnd);
        void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.ShellExtensions.IPreviewHandler)]
    public interface IPreviewHandler
    {
        void SetWindow(IntPtr hwnd, ref NativeRect rect);
        void SetRect(ref NativeRect rect);
        void DoPreview();
        void Unload();
        void SetFocus();
        void QueryFocus(out IntPtr phwnd);
        [PreserveSig]
        HResult TranslateAccelerator(ref Message pmsg);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.ShellExtensions.IPreviewHandlerFrame)]
    public interface IPreviewHandlerFrame
    {
        void GetWindowContext(IntPtr pinfo);
        [PreserveSig]
        HResult TranslateAccelerator(ref Message pmsg);
    };

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(NativeAPI.Guids.ShellExtensions.IPreviewHandlerVisuals)]
    public interface IPreviewHandlerVisuals
    {
        void SetBackgroundColor(NativeColorRef color);
        void SetFont(ref LogFont plf);
        void SetTextColor(NativeColorRef color);
    }
    #endregion

    #region Structs

    /// <summary>
    /// Class for marshaling to native LogFont struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class LogFont
    {
        /// <summary>
        /// Font height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Font width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Font escapement
        /// </summary>
        public int Escapement { get; set; }

        /// <summary>
        /// Font orientation
        /// </summary>
        public int Orientation { get; set; }

        /// <summary>
        /// Font weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Font italic
        /// </summary>
        public byte Italic { get; set; }

        /// <summary>
        /// Font underline
        /// </summary>
        public byte Underline { get; set; }

        /// <summary>
        /// Font strikeout
        /// </summary>
        public byte Strikeout { get; set; }

        /// <summary>
        /// Font character set
        /// </summary>
        public byte CharacterSet { get; set; }

        /// <summary>
        /// Font out precision
        /// </summary>
        public byte OutPrecision { get; set; }

        /// <summary>
        /// Font clip precision
        /// </summary>
        public byte ClipPrecision { get; set; }

        /// <summary>
        /// Font quality
        /// </summary>
        public byte Quality { get; set; }

        /// <summary>
        /// Font pitch and family
        /// </summary>
        public byte PitchAndFamily { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private string faceName = string.Empty;

        /// <summary>
        /// Font face name
        /// </summary>
        public string FaceName { get => faceName; set => faceName = value; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeColorRef
    {
        public uint Dword { get; set; }
    }

    #endregion
}
