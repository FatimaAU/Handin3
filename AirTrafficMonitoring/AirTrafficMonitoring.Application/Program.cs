﻿using System;
using AirTrafficMonitoring.Classes;
using AirTrafficMonitoring.Classes.Calculators;
using AirTrafficMonitoring.Classes.Calculators.Interfaces;
using AirTrafficMonitoring.Classes.Objectifier;
using AirTrafficMonitoring.Classes.Objectifier.Interfaces;
using AirTrafficMonitoring.Classes.TrackListReadyEvent;
using AirTrafficMonitoring.Classes.UpdateAndCheck;
using AirTrafficMonitoring.Classes.UpdateAndCheck.Interfaces;
using TransponderReceiver;

namespace AirTrafficMonitoring.Application
{
    class Program
    {
        public static ITransponderReceiver Receiver;
        public static readonly IMonitoredArea MonitoredArea = new MonitoredArea(90000, 10000, 20000, 500);
        public static readonly IParseTrackInfo Parser = new ParseTrackInfo();
        public static ITimestampFormatter Formatter = new TimestampFormatter();
        public static IFlightExtractor Handler = new FlightExtractor();
        public static ICourse CourseCalc = new Course();
        public static IVelocity VelocityCalc = new Velocity();
        public static IDistance Distance = new Distance();
        public static ISeparation Separation = new Separation();
        public static IListHandler TrackListHandler = new ListHandler(
            VelocityCalc, 
            CourseCalc, 
            Separation, 
            Distance);

        static void Main(string[] args)
        {
            Receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            ITrackList objectifier = new TrackObjectifier(
                Receiver, 
                MonitoredArea, 
                Parser, 
                Handler, 
                Formatter);

            ATMSystem system = new ATMSystem(objectifier, TrackListHandler);

            Console.ReadKey();
        }
    }
}

