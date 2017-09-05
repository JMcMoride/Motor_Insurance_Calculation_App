using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    static class Premium_Calculation
    {
        public static void Start(Policy policy)
        {
            if (Check_Policy_Valid(policy))
            {
                float premium = 500;
                List<Policy_Rules_Structure> policy_Rules = new List<Policy_Rules_Structure>();

                policy_Rules.Add(new Policy_Rules_Driver_Occupation(policy.Drivers));
                policy_Rules.Add(new Policy_Rules_Driver_Age(policy.Start_Date, policy.Youngest_Driver));
                policy_Rules.Add(new Policy_Rules_Driver_Claims(policy.Drivers, policy.Start_Date));


                for (int count = 0; count < policy_Rules.Count; count++)
                {
                    premium = policy_Rules[count].Check_Value(premium);
                }

                Console.WriteLine("\n\t--- Calculated premium: £" + premium.ToString("0.00") + " ---\n");
            }

            Console.WriteLine("\nPress any key to quit.");
            Console.ReadLine();
        }

        static bool Check_Policy_Valid(Policy policy)
        {

            if (policy.Start_Date < DateTime.Today)
            {
                Console.WriteLine("\n\t--- Policy declined - Start date of policy. ---\n");
                return false;
            }

            if (policy.Youngest_Driver.Start_Date_Age < 21)
            {
                Console.WriteLine("\n\t--- Policy declined - Age of Youngest Driver : " + policy.Youngest_Driver.Name + " - " + policy.Youngest_Driver.Start_Date_Age + ". ---\n");
                return false;
            }

            if (policy.Oldest_Driver.Start_Date_Age > 75)
            {
                Console.WriteLine("\n\t\tPolicy declined - - Age of Oldest Driver : " + policy.Oldest_Driver.Name + " - " + policy.Oldest_Driver.Start_Date_Age + ". ---\n");
                return false;
            }

            if (policy.Total_Claims > 3)
            {
                Console.WriteLine("\n\t--- Policy declined - Policy has more than 3 claims. ---\n");
                return false;
            }

            for(int count = 0; count < policy.Drivers.Count; count++)
            {
                if (policy.Drivers[count].Claims.Count > 2)
                {
                    Console.WriteLine("\n\t--- Policy declined - - Driver has more than 2 claims : " + policy.Drivers[count].Name + ". ---\n");
                    return false;
                }
            }

            return true;

        }
      
    }
}
