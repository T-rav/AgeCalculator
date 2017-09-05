using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = CalculateGrossAge(birthdate, today);
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

        private static int CalculateGrossAge(DateTime birthdate, DateTime today)
        {
            return today.Year - birthdate.Year;
        }
    }
}