﻿using System;

namespace AirTrafficMonitoring.Classes.Objectifier.Interfaces
{
    public interface ITrackObject
    {
        string Tag { get; }
        IPosition Position { get; set; }
        string Timestamp { get; }
        int Course { get; set; }
        int Velocity { get; set; }
        DateTime InDateTime { get; set; }
        string ToString();
    }
}
