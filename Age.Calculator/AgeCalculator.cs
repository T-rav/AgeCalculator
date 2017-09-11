using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        /* 
         * note: birthday.DayOfYear > today.DayOfYear will not work in all cases 
         * [TestCase("05,20,2001", "05,19,2016", 14)] FAILS!
         */
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = CalculateAge(birthdate, today);
            age = AdjustAge(birthdate, today, age);

            ThrowExceptionIfAgeLessThanZero(age);

            return age;
        }

        private int AdjustAge(DateTime birthdate, DateTime today, int age)
        {
            if (BirthdayYetToHappen(birthdate, today))
            {
                return --age;
            }

            return age;
        }

        private void ThrowExceptionIfAgeLessThanZero(int age)
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

        private bool BirthdayYetToHappen(DateTime birthdate, DateTime today)
        {
            var negativeAge = -1 * CalculateAge(birthdate, today);
            var canidateDate = today.AddYears(negativeAge);
            return canidateDate.CompareTo(birthdate) < 0;
        }

        private int CalculateAge(DateTime birthdate, DateTime today)
        {
            return today.Year - birthdate.Year;
        }
    }
}