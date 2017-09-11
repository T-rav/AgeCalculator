using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = CalculateAge(birthdate, today);
            /* 
             * note: birthday.DayOfYear > today.DayOfYear will not work in all cases 
             * [TestCase("05,20,2001", "05,19,2016", 14)] FAILS!
             */
            if (BirthdayHasNotHappenedYet(birthdate, today, age))
            {
                age--;
            }

            return age;
        }

        private static bool BirthdayHasNotHappenedYet(DateTime birthdate, DateTime today, int age)
        {
            var negativeAge = -1 * age;
            var canidateDate = today.AddYears(negativeAge);
            return canidateDate.CompareTo(birthdate) != 0;
        }

        private static int CalculateAge(DateTime birthdate, DateTime today)
        {
            return today.Year - birthdate.Year;
        }
    }
}