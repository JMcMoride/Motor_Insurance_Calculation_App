using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    class Policy_Rules_Driver_Occupation : Policy_Rules_Structure
    {
        readonly int add_10_Percent = 10;
        readonly string chauffeur = "Chauffeur";
        readonly string accountant = "Accountant";

        public Policy_Rules_Driver_Occupation(List<Driver> drivers) : base(drivers)
        {

        }

        public override float Check_Value(float premium)
        {
            for (int count = 0; count < drivers.Count; count++)
            {
                if (drivers[count].Occupation.Equals(chauffeur, StringComparison.InvariantCultureIgnoreCase))
                {
                    premium = Change_Premium(premium, add_10_Percent, true);
                }
                else if (drivers[count].Occupation.Equals(accountant, StringComparison.InvariantCultureIgnoreCase))
                {
                    premium = Change_Premium(premium, add_10_Percent, false);
                }
            }

            return premium;
        }
    }
}
