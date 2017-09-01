using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;

            if (IsTodayMonthBeforeBirthday(birthdate, today))
            {
                age--;
            }

            if (IsBirthdayYetToHappenThisMonth(birthdate, today))
            {
                age--;
            }

            return age;
        }

        private bool IsBirthdayYetToHappenThisMonth(DateTime birthdate, DateTime today)
        {
            return today.Month == birthdate.Month && today.Day < birthdate.Day;
        }

        private bool IsTodayMonthBeforeBirthday(DateTime birthdate, DateTime today)
        {
            return today.Month < birthdate.Month;
        }
    }
}