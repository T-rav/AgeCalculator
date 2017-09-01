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
            var birthday = DateTime.Now;
            var today = DateTime.Now;
            var expected = 0;
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
            return 0;
        }
    }
}
