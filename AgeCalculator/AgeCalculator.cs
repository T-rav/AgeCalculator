using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;

            if (BirthdayMonthIsYetToHappenThisYear(birthdate, today) || BirthdayYetToHappenThisMonth(birthdate, today))
            {
                age--;
            }

            return age;
        }

        private bool BirthdayYetToHappenThisMonth(DateTime birthdate, DateTime today)
        {
            return today.Month == birthdate.Month && today.Day < birthdate.Day;
        }

        private bool BirthdayMonthIsYetToHappenThisYear(DateTime birthdate, DateTime today)
        {
            return today.Month < birthdate.Month;
        }
    }
}