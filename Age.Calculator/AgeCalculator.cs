using System;

namespace Age.Calculator
{
    public class AgeCalculator
    {
        public int Calculate(DateTime birthdate, DateTime today)
        {
            var age = Calculate_Age(birthdate, today);

            If_Unborn_Throw_Exception(age);

            return age;
        }

        private int Calculate_Age(DateTime birthdate, DateTime today)
        {
            var age = today.Year - birthdate.Year;
            if (Birthday_Yet_To_Happen_This_Year(birthdate, today))
            {
                return --age;
            }
            return age;
        }

        private bool Birthday_Yet_To_Happen_This_Year(DateTime birthdate, DateTime today)
        {
            var negativeAge = -1 * Calculate_Age(birthdate, today);
            var canidateDate = today.AddYears(negativeAge);
            return canidateDate.CompareTo(birthdate) < 0;
        }

        private void If_Unborn_Throw_Exception(int age)
        {
            if (Not_Yet_Born(age))
            {
                throw new Exception("The given birthday means the person is unborn - cannot calculate age.");
            }
        }

        private bool Not_Yet_Born(int age)
        {
            return age < 0;
        }

    }
}
