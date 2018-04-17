﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Classes
{
    public class CalculateVelocity
    {
        public int Velocity(int oldX, int newX, int oldY, int newY)
        {
            int x = Math.Abs(newX - oldX);
            int y = Math.Abs(newY - oldY);
            

            return (int)(Math.Sqrt(x*x + y*y));
        }
    }
}