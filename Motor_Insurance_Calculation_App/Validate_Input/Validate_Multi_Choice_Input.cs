using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    class Validate_Multi_Choice_Input : Validate_Structure<string>
    {
        protected List<string> choices;
        private int user_Choice;

        public Validate_Multi_Choice_Input(string Message, List<string> Choices, string Property_Name) : base(Message, Property_Name)
        {
            choices = Choices;
        }

        private void Display_Choices()
        {
            for(int count = 0; count < choices.Count; count++)
            {
                Console.WriteLine("Enter " + (count + 1) + " for '" + choices[count] + "'");
            }
        }

        public override string Validate()
        {
            Console.WriteLine(message);
            Display_Choices();

            string user_Input;

            do
            {
                user_Input = Console.ReadLine().Trim();

            } while (!Validate_Check(user_Input));

            return return_Value;
        }

        public override bool Validate_Check(string user_Input)
        {
            if (!Int32.TryParse(user_Input, out user_Choice))
            {
                Console.WriteLine("\nInvalid input! Please enter a number.");
                return false;
            }

            if (user_Choice > choices.Count)
            {
                Console.WriteLine("\nInvalid input! Please enter a number less than " + choices.Count + ".");
                return false;
            }
            else if (user_Choice <= 0)
            {
                Console.WriteLine("\nInvalid input! Please enter a number greater than " + 0 + ".");
                return false;
            }

            Console.WriteLine("\n\t" + property_Name + ", '" + choices[user_Choice - 1] + "' accepted!\n");

            return_Value = choices[user_Choice - 1];
            return true;
        }
    }
}
