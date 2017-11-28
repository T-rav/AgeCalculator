using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthday, DateTime targetDate)
        {
            var age = CalculateAge(birthday, targetDate);

            ThrowExceptionIfUnborn(age);

            return age;
        }

        private int CalculateAge(DateTime birthday, DateTime targetDate)
        {
            var targetDateInteger = ConvertDateToInteger(targetDate);
            var birthdayInteger = ConvertDateToInteger(birthday);

            return DetermineAgeFromDateIntegers(targetDateInteger, birthdayInteger);
        }

        private static int DetermineAgeFromDateIntegers(int todayInteger, int birthdayInteger)
        {
            var yearAdjustmentFactor = 10000.00;
            // E.g. (20171128 - 19810429) / 10000.00 => 36.069
            return (int)Math.Floor((todayInteger - birthdayInteger) / yearAdjustmentFactor);
        }

        private static int ConvertDateToInteger(DateTime targetDate)
        {
            var dateString = targetDate.ToString("yyyyMMdd");
            var dateInteger = int.Parse(dateString);
            return dateInteger;
        }

        private void ThrowExceptionIfUnborn(int age)
        {
            if (IsUnborn(age))
            {
                throw new Exception("The given birthday means the person is unborn - cannot calculate age.");
            }
        }

        private bool IsUnborn(int age)
        {
            return age < 0;
        }
    }
}
