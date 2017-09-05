using System;
using System.Collections.Generic;


namespace motor_Insurance_Calculation
{
    static class Build_Policy
    {
        public static Policy Start()
        {
            Validate_Structure<DateTime> policy_Start_Date = new Validate_Date_Input("Please enter the start date of the policy, E.g " +  DateTime.Today.ToShortDateString() + ".", false, "Start Date");

            return new Policy(policy_Start_Date.Validate(),Get_Drivers());
        }

        static List<Driver> Get_Drivers()
        {
            int drivers_To_Add;
       
            List<Driver> drivers = new List<Driver>();

            Validate_Structure<string> driver_Name = new Validate_String_Input("Please enter the name of the driver, E.g Brian Smith.", 50, "Driver name");
            Validate_Structure<string> dirver_Occupation = new Validate_Multi_Choice_Input("Please select the driver's occupation:", new List<string>(){ "Chauffeur", "Accountant" }, "Occupation");
            Validate_Structure<DateTime> driver_DOB = new Validate_Date_Input("Please enter the driver's date of birth, E.g 05/09/1985.", true, "Date of birth");
            Validate_Structure<int> add_Drivers_Check = new Validate_Integer_Range_Input("Please enter the number of drivers to add to this policy (1-5).", 1, 5);

            drivers_To_Add = add_Drivers_Check.Validate();

            for (int count = 0; count < drivers_To_Add; count++)
            {
                Console.WriteLine("\n\t\t ---- Driver " + (count + 1) + "! ---\n");
                drivers.Add(new Driver(driver_Name.Validate(), dirver_Occupation.Validate(), driver_DOB.Validate(), Get_Driver_Claims()));

            }

            return drivers; 
        }
         
        static List<DateTime> Get_Driver_Claims()
        {
            int claims_To_Add;

            List<DateTime> claims = new List<DateTime>();

            Validate_Structure<DateTime> claim_Date = new Validate_Date_Input("Please enter the date of the claim, E.g 01/05/1985", true, "Date of claim");
            Validate_Structure<int> add_Claim_Check = new Validate_Integer_Range_Input("Please enter the number of claims to add to this driver (0-5).",0,5);

            claims_To_Add = add_Claim_Check.Validate();

            for (int count = 0; count < claims_To_Add; count++)
            {
                Console.WriteLine("\n\t\t  --- Claim " + (count + 1) + "! ---\n");
                claims.Add(claim_Date.Validate());
            }

            return claims;
        }
    }
}
