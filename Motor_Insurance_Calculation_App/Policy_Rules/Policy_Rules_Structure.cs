
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    abstract class Policy_Rules_Structure
    {
        protected List<Driver> drivers;

        public Policy_Rules_Structure(List<Driver> Drivers)
        {
            drivers = Drivers;
        }

        public Policy_Rules_Structure()
        {
            
        }
        public abstract float Check_Value(float Current_Premium);

        protected float Change_Premium(float current_Premium, int percentage, bool increase)
        {
            if (increase)
            {
                current_Premium += current_Premium * percentage / 100;
            }
            else
            {
                current_Premium -= current_Premium * percentage / 100;
            }

            return current_Premium;
        }

    }
}
