﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
namespace Microsoft.WindowsAPICodePack.Sensors
{
    /// <summary>
    /// Represents a 3D accelerometer.
    /// </summary>
    [SensorDescription("C2FB0F5F-E2D2-4C78-BCD0-352A9582819D")]
    public class Accelerometer3D : Sensor
    {
        /// <summary>
        /// Gets the current acceleration in G's. 
        /// </summary>
        public Acceleration3D CurrentAcceleration => new Acceleration3D(DataReport);
    }

    /// <summary>
    /// Specifies the axis of the acceleration measurement.
    /// </summary>
    public enum AccelerationAxis
    {
        /// <summary>
        /// The x-axis.
        /// </summary>        
        XAxis = 0,
        /// <summary>
        /// The y-axis.
        /// </summary>        
        YAxis = 1,
        /// <summary>
        /// THe z-axis.
        /// </summary>        
        ZAxis = 2
    }

    /// <summary>
    /// Creates an acceleration measurement from the data in the report.
    /// </summary>
    public class Acceleration3D
    {
        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="report">The sensor report to evaluate.</param>
        public Acceleration3D(in SensorReport report)
        {
            if (report == null)  throw new ArgumentNullException(nameof(report)); 

            acceleration[(int)AccelerationAxis.XAxis] =
                (float)report.Values[PropertySystem.DataType.Motion.AccelerationXG.FormatId][0];
            acceleration[(int)AccelerationAxis.YAxis] =
                (float)report.Values[PropertySystem.DataType.Motion.AccelerationYG.FormatId][1];
            acceleration[(int)AccelerationAxis.ZAxis] =
                (float)report.Values[PropertySystem.DataType.Motion.AccelerationZG.FormatId][2];
        }

        /// <summary>
        /// Gets the acceleration reported by the sensor.
        /// </summary>
        /// <param name="axis">The axis of the acceleration.</param>
        /// <returns></returns>
        public float this[in AccelerationAxis axis] => acceleration[(int)axis];

        private readonly float[] acceleration = new float[3];
    }
}
