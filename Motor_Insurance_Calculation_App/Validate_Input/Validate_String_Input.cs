using System;
using System.Text.RegularExpressions;

namespace motor_Insurance_Calculation
{
    class Validate_String_Input : Validate_Structure<string>
    {
        protected int max_Size;

        public Validate_String_Input(string Message, int Max_Size, string Property_Name) : base(Message, Property_Name)
        {
            max_Size = Max_Size;
        }

        public override bool Validate_Check(string user_Input)
        {
            if (!Regex.IsMatch(user_Input, "^[a-z A-Z]+$"))
            {
                Console.WriteLine("\nInvalid input! Please enter a value using upper and lowercase letters only.");
                return false;
            }
            else if (user_Input.Length > max_Size)
            {
                Console.WriteLine("\nInvalid input! Please enter a value less than " + max_Size + " characters.");
                return false;
            }

            Console.WriteLine("\n\t" + property_Name + ", '" + user_Input + "' accepted!\n");

            return_Value = user_Input;
            return true;
        }
    }
}
