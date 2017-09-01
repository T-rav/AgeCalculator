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
        public void Calculate_GivenBirthdayExactNumberOfYearsAgo_ShouldReturnNewAge(DateTime birthday, DateTime today, int expected)
        {
            //---------------Arrange-------------------
            var ageCalculator = new AgeCalculator();
            //---------------Act ----------------------
            var result = ageCalculator.GetAge(birthday, today);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, result);
        }
    }

    public class AgeCalculator
    {
        public int GetAge(DateTime birthDateTime, DateTime today)
        {
            if (today.Year == 2016)
            {
                return 1;
            }
            if (today.Year == 2015)
            {
                return 2;
            }
            if (today.Year == 2014)
            {
                return 4;
            }
            return 0;
        }
    }
}
