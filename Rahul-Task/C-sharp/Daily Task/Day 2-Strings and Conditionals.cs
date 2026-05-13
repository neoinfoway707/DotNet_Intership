using System;
using System.ComponentModel;
using System.Configuration;
namespace C_sharp.Daily_Task
{
    internal class Day_2_Strings_and_Conditionals
    {
        static void Main(string[] args)
        {
            //Create String variables
            string myString = "This is My New String.";
            string newString = "This is My Other New String.";
            Console.WriteLine("Original String: " + myString);
            Console.WriteLine("Length of String: " + myString.Length);
            Console.WriteLine("\n\n============== Strgin Methods ==============");

            //String Methods
            Console.WriteLine($"Upper Case Method: {myString.ToUpper()}");
            Console.WriteLine($"Lower Case Method: {myString.ToLower()}");
            Console.WriteLine($"Index Of Method: {myString.IndexOf("N")}");
            Console.WriteLine("Concat Method: " + String.Concat(myString, newString));
            Console.WriteLine("Contains Method: " + myString.Contains("My"));
            Console.WriteLine("Replace Method: " + myString.Replace("My", "First"));
            Console.WriteLine("Substring Method: " + myString.Substring(8));


            int myInt = 7;
            Console.WriteLine("\n============== If Else Statement ==============");
            //if...else Statement
            if (myInt > 0)
            {
                Console.WriteLine("Integer is greater than 0");
            }
            else
            {
                Console.WriteLine("Integer is Negative");
            }

            Console.WriteLine("\n============== If Else ladder ==============");
            //Using If else ladder
            if (myInt > 5 && myInt <= 10)
            {
                Console.WriteLine("Integer is between 5 to 10");
            }
            else if (myInt > 0 && myInt <= 5)
            {
                Console.WriteLine("Integer is between 1 to 5");
            }
            else
            {
                Console.WriteLine("Select Correct Integer between 1 to 10");
            }

            //Nested If else statement
            Console.WriteLine("\n============== Nested If Else Statement ==============");
            if (myInt > 0)
            {
                if (myInt > 5 && myInt <= 10)
                {
                    Console.WriteLine("Integer is between 5 to 10");
                }
                else
                {
                    Console.WriteLine("Integer is less than 5");
                }
            }
            else
            {
                if (myInt > 10)
                {
                    Console.WriteLine("Integer is greater than 10");
                }
                else
                {
                    Console.WriteLine("Integer is must between 1 to 10");
                }
            }

            Console.WriteLine("Enter First Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            //Switch Statement
            while (true)
            {
                Console.WriteLine("\n============== Switch Statement ==============");
                Console.WriteLine("1.Add Number");
                Console.WriteLine("2.Minus Number");
                Console.WriteLine("3.Divide Number");
                Console.WriteLine("4.Multiply Number");
                Console.WriteLine("5.Exit");

                Console.WriteLine("Enter a Number between 1 to 5: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine($"Addition of {num1} and {num2} is:  {num1 + num2}");
                        break;
                    case 2:
                        Console.WriteLine($"Subtraction of {num1} and {num2} is:  {num1 - num2}");
                        break;
                    case 3:
                        Console.WriteLine($"Division of {num1} and {num2} is:  {num1 / num2}");
                        break;
                    case 4:
                        Console.WriteLine($"Multiplication of {num1} and {num2} is:  {num1 * num2}");
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}