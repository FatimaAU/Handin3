﻿using System.Collections.Generic;
using System.Linq;

namespace AirTrafficMonitoring.Classes
{
    public class ParseTrackInfo
    {
        private List<string> _flightList;
        public ParseTrackInfo(string data)
        {
            _flightList = data.Split(';').ToList();
        }
    }
}
