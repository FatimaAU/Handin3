﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Classes.Objectifier.Interfaces
{
    public interface IPositionFactory
    {
        IPosition CreatePosition(int x, int y, int al);
    }
}
