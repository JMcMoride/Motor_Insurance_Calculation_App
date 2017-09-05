using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    class Policy_Rules_Driver_Age : Policy_Rules_Structure
    {
        protected DateTime start_Date;
        protected Driver youngest_Driver;

        public Policy_Rules_Driver_Age(DateTime Start_Date, Driver Youngest_Driver) : base()
        {
            start_Date = Start_Date;
            youngest_Driver = Youngest_Driver;
        }

        public override float Check_Value(float premium)
        {
            if (youngest_Driver.Start_Date_Age >= 21 && youngest_Driver.Start_Date_Age <= 25)
            {
                premium = Change_Premium(premium, 20, true);
            }
            else if (youngest_Driver.Start_Date_Age >= 26 && youngest_Driver.Start_Date_Age <= 75)
            {
                premium = Change_Premium(premium, 10, false);
            }

            return premium;
        }
    }
}
