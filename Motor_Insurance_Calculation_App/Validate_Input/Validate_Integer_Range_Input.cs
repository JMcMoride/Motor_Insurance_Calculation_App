using System;

namespace motor_Insurance_Calculation
{
    class Validate_Integer_Range_Input : Validate_Structure<int>
    {
        protected int max;
        protected int min;


        public Validate_Integer_Range_Input(string Message, int Min, int Max) : base(Message)
        {
            max = Max;
            min = Min;
        }

        public override bool Validate_Check(string user_Input)
        {
            if (!Int32.TryParse(user_Input, out return_Value))
            {
                Console.WriteLine("\nInvalid input! Please enter a number.");
                return false;
            }

            if (return_Value > max)
            {
                Console.WriteLine("\nInvalid input! Please enter a number less than " + max + ".");
                return false;
            }
            else if(return_Value < min)
            {
                Console.WriteLine("\nInvalid input! Please enter a number greater than " + min + ".");
                return false;
            }

            return true;
        }
    }
}
