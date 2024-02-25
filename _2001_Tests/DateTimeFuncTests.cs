using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2001_Lib;
using System;

namespace _2001_Tests
{
    [TestClass]
    public class DateTimeFuncTests
    {
        [TestMethod]       
        public void TwoDatesDif_return3()
        {
            var date1 = new DateTime(2024, 2, 10);
            var date2 = new DateTime(2024, 2, 7);
            string expected = "Разница составляет: 3 дн(ей/я)";

            DateTimeFunctions func = new DateTimeFunctions();
            string actual = func.TwoDatesDifference(date1, date2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeapYearTrue()
        {
            int date = 2004;
            bool expected = true;

            DateTimeFunctions func = new DateTimeFunctions();
            bool actual = func.LeapYear(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TimeOfDayEvening()
        {
            DateTime time = DateTime.Now;
            
            string expected = "Вечер";

            DateTimeFunctions func = new DateTimeFunctions();
            string actual = func.TimeOfDay(time);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NewYearFormat()
        {
            DateTime dateTime = new DateTime(2024, 1, 1);

            string expected = "01.01.2024 00:00:00";

            DateTimeFunctions func = new DateTimeFunctions();
            string actual = func.DateTimeFormat(dateTime);

            Assert.AreEqual(expected, actual);
        }
    }
}
