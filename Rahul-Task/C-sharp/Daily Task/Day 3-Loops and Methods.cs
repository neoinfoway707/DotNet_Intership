using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task
{
    internal class Day_3_Loops_and_Methods
    {

        static void Main(string[] args)
        {
            // Print 1 to 10 table using nested loop
            Console.WriteLine("============= Nested Loop =============\n");
            int table = 0;
            for (int i = 1; i <= 10; i++)
            {
                table = 1;
                while (table <= 10)
                {
                    Console.WriteLine($"{i} x {table} = {table * i}");
                    table++;
                }
                Console.WriteLine();
            }

            //Sum of numbers in an array
            Console.WriteLine("============== Sum of Numbers ==============");
            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            SumOfArray(arr);


            //Factorial of a number using method
            Console.WriteLine("\n\n============== Factorial of a Number using Method ==============");
            Console.Write("Enter Number for factorial: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Factorial of {num} is: " + factorial(num));

            //Method Overloading
            Console.WriteLine("\n\n============== Method Overloading ==============");
            Console.WriteLine("Addition of 10 and 20 is: " + Add(10, 20));
            Console.WriteLine("Addition of 10.5 and 20.5 is: " + Add(10.5, 20.5));
        }
        static void SumOfArray(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("Total Sum of Array is: " + sum);
        }
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        static int factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            int result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}