﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Classes.Objectifier;
using AirTrafficMonitoring.Classes.Objectifier.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitoring.Test.Integration
{
    [TestFixture]
    class IT2_MonitoredArea
    {
        private IMonitoredArea _uut;
        private TrackObjectifier _trackObjectifier;
        private IPosition _position;
        private ITransponderReceiver _transponderReceiver;
        private IMonitoredArea _monitoredArea;
        private IParseTrackInfo _parseTrackInfo;
        private IFlightExtractor _flightExtractor;
        private ITimestampFormatter _timestampFormatter;
        private IList<ITrackObject> _trackList;

        private List<string> _argList;
        private RawTransponderDataEventArgs _args;

        [SetUp]
        public void Setup()
        {
            _uut = new MonitoredArea(90000, 10000, 20000, 500);
            _trackObjectifier = new TrackObjectifier(_transponderReceiver, _monitoredArea, _parseTrackInfo, _flightExtractor, _timestampFormatter);
            _position = Substitute.For<IPosition>();

            _argList = new List<string> { "ATR423;39045;12932;14000;20151006213456789" };
            _args = new RawTransponderDataEventArgs(_argList);

            _trackObjectifier.TrackListReady += (sender, updatedArgs) =>
            {
                _trackList = updatedArgs.TrackList;
            };
        }

        [Test]
        public void CreateTrack_()
        {
            _uut.InsideMonitoredArea(_flightExtractor.Position).Returns(true);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_args);

            var temp = _position.Received().XCoor;
        }
    }
}
