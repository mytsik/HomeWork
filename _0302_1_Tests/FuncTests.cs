using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _0302_1_Lib;

namespace _0302_1_Tests
{
    [TestClass]
    public class FuncTests
    {
        [TestMethod]
        public void ConnectionCheckTrue()
        {
            string connStr = "Data Source=C:\\Users\\Yanina\\OneDrive\\Рабочий стол\\база данных\\TrianglesDATABASE.db";
            bool expected = true;

            Functions func = new Functions();
            bool actual = func.DBConnection(connStr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidEmailTrue()
        {
            string email = "cryptographer24601@gmail.com";
            bool expected = true;

            Functions func = new Functions();
            bool actual = func.IsValidEmail(email);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhoneNumberTrue()
        {
            string number = "8-920-578-24-67";
            bool expected = true;

            Functions func = new Functions();
            bool actual = func.IsValidPhoneNumber(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
