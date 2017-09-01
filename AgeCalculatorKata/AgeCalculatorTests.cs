using System;
using NUnit.Framework;

namespace Age.Calculator.Tests
{
    [TestFixture]
    public class AgeCalculatorTests
    {
        [Test]
        public void Calculate_GivenBirthdayToday_ShouldReturnZero()
        {
            //---------------Arrange-------------------
            var birthday = DateTime.Parse("01,01,2017");
            var today = DateTime.Parse("01,01,2017");
            var expected = 0;
            var ageCalculator = new AgeCalculator();
            //---------------Act ----------------------
            var result = ageCalculator.GetAge(birthday, today);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("01,01,2015","01,01,2016", 1)]
        [TestCase("01,01,2013", "01,01,2015", 2)]
        [TestCase("01,01,2010", "01,01,2014", 4)]
        [TestCase("02,29,2012", "02,29,2016", 4)]
        public void Calculate_GivenBirthdayExactNumberOfYearsAgo_ShouldReturnAgePlusOne(DateTime birthday, DateTime today, int expected)
        {
            //---------------Arrange-------------------
            var ageCalculator = new AgeCalculator();
            //---------------Act ----------------------
            var result = ageCalculator.GetAge(birthday, today);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("04,29,2000", "03,29,2017", 16)]
        [TestCase("05,20,2001", "04,20,2016", 14)]
        [TestCase("06,10,2002", "05,20,2014", 11)]
        public void Calculate_GivenBirthdayOneMonthAway_ShouldReturnCurrentAge(DateTime birthday, DateTime today, int expected)
        {
            //---------------Arrange-------------------
            var ageCalculator = new AgeCalculator();
            //---------------Act ----------------------
            var result = ageCalculator.GetAge(birthday, today);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("04,29,2000", "04,28,2017", 16)]
        [TestCase("05,20,2001", "05,19,2016", 14)]
        [TestCase("06,10,2002", "06,09,2014", 11)]
        [TestCase("02,29,2012", "02,28,2014", 1)]
        public void Calculate_GivenBirthdayOneDayAway_ShouldReturnCurrentAge(DateTime birthday, DateTime today, int expected)
        {
            //---------------Arrange-------------------
            var ageCalculator = new AgeCalculator();
            //---------------Act ----------------------
            var result = ageCalculator.GetAge(birthday, today);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, result);
        }
    }
}
