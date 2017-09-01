using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;

            if (BirthdayMonthIsYetToHappen(birthdate, today) || BirthdayYetToHappenThisMonth(birthdate, today))
            {
                age--;
            }

            return age;
        }

        private bool BirthdayYetToHappenThisMonth(DateTime birthdate, DateTime today)
        {
            return today.Month == birthdate.Month && today.Day < birthdate.Day;
        }

        private bool BirthdayMonthIsYetToHappen(DateTime birthdate, DateTime today)
        {
            return today.Month < birthdate.Month;
        }
    }
}