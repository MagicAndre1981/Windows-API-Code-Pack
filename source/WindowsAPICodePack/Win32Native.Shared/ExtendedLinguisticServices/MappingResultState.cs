//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;

namespace Microsoft.WindowsAPICodePack.ExtendedLinguisticServices
{
    /// <summary>
    /// This class serves as the result status of asynchronous calls to ELS and
    /// as the result status of linguistic exceptions.
    /// </summary>
    public struct MappingResultState : IEquatable<MappingResultState>
    {
        internal MappingResultState(in int hResult, in string errorMessage)
        {
            HResult = hResult;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets a human-readable description of the HResult error code,
        /// as constructed by <see cref="System.ComponentModel.Win32Exception">Win32Exception</see>.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the HResult error code associated with this structure.
        /// </summary>
        public int HResult { get; }

        /// <summary>
        /// Uses the HResult param as the object hashcode.
        /// </summary>
        /// <returns>An integer hashcode</returns>
        public override int GetHashCode() => HResult;

        /// <summary>
        /// Compares an Object for value equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if obj is equal to this instance, false otherwise.</returns>
        public override bool Equals(object obj) => obj == null ? false : ReferenceEquals(obj, this) ? true : obj is MappingResultState ? Equals((MappingResultState)obj) : false;

        /// <summary>
        /// Compares a <see cref="MappingResultState">MappingResultState</see> obj for value equality.
        /// </summary>
        /// <param name="obj"><see cref="MappingResultState">MappingResultState</see> to compare.</param>
        /// <returns>True if obj is equal to this instance, false otherwise.</returns>
        public bool Equals(MappingResultState obj) => obj.HResult == HResult;

        /// <summary>
        /// Compares two <see cref="MappingResultState">MappingResultState</see> objs for value equality.
        /// </summary>
        /// <param name="one">First <see cref="MappingResultState">MappingResultState</see> to compare.</param>
        /// <param name="two">Second <see cref="MappingResultState">MappingResultState</see> to compare.</param>
        /// <returns>True if the two <see cref="MappingResultState">MappingResultStates</see> are equal, false otherwise.</returns>
        public static bool operator ==(MappingResultState one, MappingResultState two) => one.Equals(two);

        /// <summary>
        /// Compares two <see cref="MappingResultState">MappingResultState</see> objs against value equality.
        /// </summary>
        /// <param name="one">First <see cref="MappingResultState">MappingResultState</see> to compare.</param>
        /// <param name="two">Second <see cref="MappingResultState">MappingResultState</see> to compare.</param>
        /// <returns>True if the two <see cref="MappingResultState">MappingResultStates</see> are not equal, false otherwise.</returns>
        public static bool operator !=(MappingResultState one, MappingResultState two) => !one.Equals(two);
    }
}
