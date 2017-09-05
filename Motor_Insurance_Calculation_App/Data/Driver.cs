using System;
using System.Collections.Generic;


namespace motor_Insurance_Calculation
{
    class Driver
    {
        public Driver(string name, string occupation, DateTime date_of_Birth, List<DateTime> claims)
        {
            Name = name;
            Occupation = occupation;
            Date_of_Birth = date_of_Birth;
            Claims = claims;
        }

        public List<DateTime> Claims
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public String Occupation
        {
            get;
            set;
        }

        public DateTime Date_of_Birth
        {
            get;
            set;
        }

        public int Start_Date_Age
        {
            get;
            set;
        }

    }
}
