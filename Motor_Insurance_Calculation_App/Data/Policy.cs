using System;
using System.Collections.Generic;


namespace motor_Insurance_Calculation
{
    class Policy
    {
        public Policy(DateTime start_Date, List<Driver> drivers)
        {
            Start_Date = start_Date;
            Drivers = drivers;

            Set_Up_Policy_Info();
        }

        public DateTime Start_Date
        {
            get;
            set;
        }

        public List<Driver> Drivers
        {
            get;
            set;
        }

        public int Total_Claims
        {
            get;
            set;
        }

        public Driver Youngest_Driver
        {
            get;
            set;
        }

        public Driver Oldest_Driver
        {
            get;
            set;
        }

        private void Set_Up_Policy_Info()
        {
            Youngest_Driver = Drivers[0];
            Oldest_Driver = Drivers[0];

            for (int count = 0; count < Drivers.Count; count++)
            {
                Total_Claims += Drivers[count].Claims.Count;

                if (Drivers[count].Date_of_Birth < Youngest_Driver.Date_of_Birth)
                {
                    Youngest_Driver = Drivers[count];
                }

                if (Drivers[count].Date_of_Birth < Oldest_Driver.Date_of_Birth)
                {
                    Oldest_Driver = Drivers[count];
                }
            }

            Set_Up_Policy_Start_Date_Age(Youngest_Driver);
            Set_Up_Policy_Start_Date_Age(Oldest_Driver);
        }

        private void Set_Up_Policy_Start_Date_Age(Driver driver)
        {
            int policy_Start_Age = Start_Date.Year - driver.Date_of_Birth.Year;

            if (Start_Date < driver.Date_of_Birth.AddYears(policy_Start_Age))
            {
                policy_Start_Age--;
            }

            driver.Start_Date_Age = policy_Start_Age;
        }
    }
}
