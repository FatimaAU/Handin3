﻿using System;
using System.Collections.Generic;

namespace AirTrafficMonitoring.Classes
{
    public class MonitoredArea
    {
        private readonly int _coordinateHigher;
        private readonly int _coordinateLower;
        private readonly int _altitudeHigher;
        private readonly int _altitudeLower;

        public MonitoredArea(int cH, int cL, int aH, int aL)
        {
            _coordinateHigher = cH;
            _coordinateLower = cL;
            _altitudeHigher = aH;
            _altitudeLower = aL;
        }

        public bool InsideMonitoredArea(string x, string y, string alt)
        {
            return InsideMonitoredCoordinates(x, y)
                   && InsideMonitoredAltitude(alt);
        }

        private bool InsideMonitoredCoordinates(string x, string y)
        {
            return InsideMonitoredXCoor(x) && InsideMonitoredYCoor(y);
        }

        private bool InsideMonitoredXCoor(string x)
        {
            return int.Parse(x) <= _coordinateHigher 
                   && int.Parse(x) >= _coordinateLower;
        }

        private bool InsideMonitoredYCoor(string y)
        {
            return int.Parse(y) <= _coordinateHigher
                   && int.Parse(y) >= _coordinateLower;
        }

        private bool InsideMonitoredAltitude(string alt)
        {
            return int.Parse(alt) >= _altitudeLower
                   && int.Parse(alt) <= _altitudeHigher;
        }

    }
}