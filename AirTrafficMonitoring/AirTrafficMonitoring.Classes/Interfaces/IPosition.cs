﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Classes.Interfaces
{
    public interface IPosition
    {
        string XCoor { get; }
        string YCoor { get; }
        string Altitude { get; }
        void SetPosition(string x, string y, string alt);
    }
}
