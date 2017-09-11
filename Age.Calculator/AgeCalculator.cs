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
            if (BirthdayHasNotHappenedYet(birthdate, today, age))
            {
                age--;
            }

            ThrowExceptionIfAgeLessThanZero(age);

            return age;
        }

        private void ThrowExceptionIfAgeLessThanZero(int age)
        {
            if (age < 0)
            {
                throw new Exception("The given birthday means the person is unborn - cannot calculate age.");
            }
        }

        private bool BirthdayHasNotHappenedYet(DateTime birthdate, DateTime today, int age)
        {
            var negativeAge = -1 * age;
            var canidateDate = today.AddYears(negativeAge);
            return canidateDate.CompareTo(birthdate) != 0;
        }

        private int CalculateAge(DateTime birthdate, DateTime today)
        {
            return today.Year - birthdate.Year;
        }
    }
}