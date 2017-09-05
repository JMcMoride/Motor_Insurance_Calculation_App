using System;
using System.Collections.Generic;

namespace motor_Insurance_Calculation
{
    abstract class Validate_Structure<T>
    {
        protected string message;
        protected string property_Name;
        protected T return_Value;

        public Validate_Structure(string Message, string Property_Name)
        {
            message =  Message;
            property_Name = Property_Name;
        }

        public Validate_Structure(string Message)
        {
            message = Message;
        }

        public virtual T Validate()
        {
            string user_Input;
            Console.WriteLine(message);

            do
            {
                user_Input = Console.ReadLine().Trim();

            } while (!Validate_Check(user_Input));

            return return_Value;
        }

        public abstract bool Validate_Check(string user_Input);
    }
}
