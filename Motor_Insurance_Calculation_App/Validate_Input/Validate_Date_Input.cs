using System;
using System.Globalization;


namespace motor_Insurance_Calculation
{
    class Validate_Date_Input : Validate_Structure<DateTime>
    {
        private bool check_Date;

        public Validate_Date_Input(string Message, bool Check_Date, string Property_Name) : base(Message, Property_Name)
        {
            check_Date = Check_Date;
        }

        public override bool Validate_Check(string user_Input)
        {
            if (!DateTime.TryParseExact(user_Input, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out return_Value))
            {
                Console.WriteLine("\nInvalid input! Please enter a valid date useing the following date format, DD/MM/YYYY - " +  DateTime.Today.ToShortDateString() + ".");
                return false;
            }
            else if (check_Date && return_Value >= DateTime.Today)
            {
                Console.WriteLine("\nInvalid input! Please enter a date before today!");
                return false;
            }

            Console.WriteLine("\n\t" + property_Name + ", '" + return_Value.ToShortDateString() + "' accepted!\n");
            return true;
        }
    }
}
