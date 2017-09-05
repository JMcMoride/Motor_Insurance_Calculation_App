using System;

namespace motor_Insurance_Calculation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\t--- Motor Insurance Calculator! ---\n");
            Console.WriteLine("\t    ==========================\n");

            Premium_Calculation.Start(Build_Policy.Start());
        }
     
    }
}
