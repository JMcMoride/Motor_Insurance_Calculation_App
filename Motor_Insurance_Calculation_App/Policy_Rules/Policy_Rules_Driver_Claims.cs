using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    class Policy_Rules_Driver_Claims : Policy_Rules_Structure
    {
        protected DateTime start_Date;

        readonly int add_10_Percent = 10;
        readonly int add_20_Percent = 20;
        readonly int One_Year = 1;
        readonly int Five_Years = 5;

        public Policy_Rules_Driver_Claims(List<Driver> drivers, DateTime Start_Date) : base(drivers)
        {
            start_Date = Start_Date;
        }

        public override float Check_Value(float premium)
        {
            for (int count = 0; count < drivers.Count; count++)
            {
                foreach (DateTime claim in drivers[count].Claims)
                {
                    if (claim >= start_Date.AddYears(-One_Year) && claim <= start_Date.AddYears(One_Year))
                    {
                        premium = Change_Premium(premium, add_20_Percent, true);
                    }
                    else if (claim >= start_Date.AddYears(-Five_Years) && claim <= start_Date.AddYears(Five_Years))
                    {
                        premium = Change_Premium(premium, add_10_Percent, true);
                    }
                }
            }

            return premium;
        }
    }
}
