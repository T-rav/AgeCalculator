using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        private const int CanidateDateYear = 2004;

        public int GetAge(DateTime birthdate, DateTime today)
        {
            var age = CalculateAge(birthdate, today);

            ThrowExceptionIfUnborn(age);

            return age;
        }

        private int CalculateAge(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;
            return AdjustAgeIfBirthdayYetToHappen(birthdate, today, age);
        }

        private int AdjustAgeIfBirthdayYetToHappen(DateTime birthdate, DateTime today, int age)
        {
            if (BirthdayYetToHappen(birthdate, today))
            {
                return --age;
            }

            return age;
        }

        private void ThrowExceptionIfUnborn(int age)
        {
            if (IsUnborn(age))
            {
                throw new Exception("The given birthday means the person is unborn - cannot calculate age.");
            }
        }

        private bool BirthdayYetToHappen(DateTime birthdate, DateTime today)
        {
            var canidateBirthday = new DateTime(CanidateDateYear, birthdate.Month, birthdate.Day);
            var canidateTargetDate = new DateTime(CanidateDateYear, today.Month, today.Day);
            return canidateTargetDate.CompareTo(canidateBirthday) < 0;
        }

        private bool IsUnborn(int age)
        {
            return age < 0;
        }
    }
}
