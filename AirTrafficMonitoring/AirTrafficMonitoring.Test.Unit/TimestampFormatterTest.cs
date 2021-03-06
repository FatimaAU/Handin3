﻿using System;
using System.Collections.Generic;
using AirTrafficMonitoring.Classes;
using AirTrafficMonitoring.Classes.Objectifier;
using AirTrafficMonitoring.Classes.Objectifier.Interfaces;
using NUnit.Framework;

namespace AirTrafficMonitoring.Test.Unit
{
    /*
     * UNIT TEST DESCRIPTION
     * Unit tests on DateTest that test the time stamp is formatted correctly in all cases
     */
    [TestFixture]
    class TimestampFormatterTest
    {
        private ITimestampFormatter _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new TimestampFormatter();
        }

        [TestCase("01", "January")]
        [TestCase("02", "February")]
        [TestCase("03", "March")]
        [TestCase("04", "April")]
        [TestCase("05", "May")]
        [TestCase("06", "June")]
        [TestCase("07", "July")]
        [TestCase("08", "August")]
        [TestCase("09", "September")]
        [TestCase("10", "October")]
        [TestCase("11", "November")]
        [TestCase("12", "December")]
        public void TimestampFormatter_NumberOfMonthConverts_ReturnsFormattedOutput(string number, string month)
        {
            // Define expected time stamp
            string expectedTimestamp= $"{month} 11th, 2018, at 11:11:11 and 111 milliseconds";
            // Only the month will be changed, check equal
            _uut.Unformatted = $"2018{number}11111111111";

            _uut.FormatTimestamp();

            Assert.AreEqual(expectedTimestamp, _uut.InPretty);
        }

        [TestCase("01", "st")]
        [TestCase("02", "nd")]
        [TestCase("03", "rd")]
        [TestCase("04", "th")]
        [TestCase("05", "th")]
        [TestCase("10", "th")]
        [TestCase("11", "th")]
        [TestCase("12", "th")]
        [TestCase("13", "th")]
        [TestCase("21", "st")]
        [TestCase("22", "nd")]
        [TestCase("23", "rd")]
        [TestCase("24", "th")]
        [TestCase("30", "th")]
        [TestCase("31", "st")]
        public void TimestampFormatter_TimestampOutputCorrect_ReturnsWithCorrectSuffix(string number, string postfix)
        {
            // Parse "number" to be only one number
            string shortNumber = $"{int.Parse(number)}";
            // Timestamp defined by day and postfix
            string expectedTimestamp = $"December {shortNumber}{postfix}, 2018, at 11:11:11 and 111 milliseconds";

            _uut.Unformatted = $"201812{number}111111111";

            _uut.FormatTimestamp();

            Assert.AreEqual(expectedTimestamp, _uut.InPretty);
        }

        [TestCase("01", "January")]
        [TestCase("02", "February")]
        [TestCase("03", "March")]
        [TestCase("04", "April")]
        [TestCase("05", "May")]
        [TestCase("06", "June")]
        [TestCase("07", "July")]
        [TestCase("08", "August")]
        [TestCase("09", "September")]
        [TestCase("10", "October")]
        [TestCase("11", "November")]
        [TestCase("12", "December")]
        public void TimestampFormatter_DateTimeOutputCorrect_ReturnsCorrect(string number, string month)
        {
            _uut.Unformatted = $"2018{number}11111111111";

            DateTime expectedDateTime = new DateTime(2018, int.Parse(number), 11, 11, 11, 11, 111);

            _uut.FormatTimestamp();

            Assert.AreEqual(expectedDateTime, _uut.InDateTime);
        }

        [TestCase("01", "st")]
        [TestCase("02", "nd")]
        [TestCase("03", "rd")]
        [TestCase("04", "th")]
        [TestCase("05", "th")]
        [TestCase("10", "th")]
        [TestCase("11", "th")]
        [TestCase("12", "th")]
        [TestCase("13", "th")]
        [TestCase("21", "st")]
        [TestCase("22", "nd")]
        [TestCase("23", "rd")]
        [TestCase("24", "th")]
        [TestCase("30", "th")]
        [TestCase("31", "st")]
        public void TimestampFormatter_DateTime_ReturnsWithCorrectSuffix(string number, string postfix)
        {
            _uut.Unformatted = $"201812{number}111111111";

            DateTime expectedDateTime = new DateTime(2018, 12, int.Parse(number), 11, 11, 11, 111);

            _uut.FormatTimestamp();

            Assert.AreEqual(expectedDateTime, _uut.InDateTime);
        }

        [Test]
        public void TimestampFormatter_UnformattedStringIsNull_ReturnsException()
        {
            Assert.Throws<NullReferenceException>(() => _uut.FormatTimestamp());
        }
    }
}
