﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Classes;
using AirTrafficMonitoring.Classes.Objectifier;
using AirTrafficMonitoring.Classes.Objectifier.Interfaces;
using NUnit.Framework;

namespace AirTrafficMonitoring.Test.Unit
{
    /*
    * UNIT TEST DESCRIPTION
    * Unit tests on Position that test the correct
    * position is returned when assigned
    */
    [TestFixture]
    class PositionTest
    {
        private IPosition _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Position(5000, 3000, 2000);
        }

        [Test]
        public void Timestamp_SetXCoordinate_ReturnsXCoordinate()
        {
            int x = 20000;
            _uut.SetPosition(x, 50000, 5000);
            Assert.AreEqual(x, _uut.XCoor);
        }

        [Test]
        public void Timestamp_SetYCoordinate_ReturnsYCoordinate()
        {
            int y = 20000;
            _uut.SetPosition(50000, y, 5000);
            Assert.AreEqual(y, _uut.YCoor);
        }

        [Test]
        public void Timestamp_SetAltitude_ReturnsAltitude()
        {
            int altitude = 2000;
            _uut.SetPosition(50000, 50000, altitude);
            Assert.AreEqual(altitude, _uut.Altitude);
        }
    }
}
