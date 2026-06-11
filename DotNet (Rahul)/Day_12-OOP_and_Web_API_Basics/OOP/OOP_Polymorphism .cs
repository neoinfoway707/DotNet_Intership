using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12_OOP_and_Web_API_Basics
{
    internal class OOP_Polymorphism
    {
        public class Area
        {
            public virtual double CalArea(double width, double height)
            {
                return width * height;
            }
        }
        public class Calculate : Area
        {
            public override double CalArea(double width, double height)
            {
                Console.WriteLine($"Sum of width and height is{Cal(width,height)}");
                return width * height;
            }

            public double Cal(double num1, double num2)
            {
                return num1 + num2;
            }
            public double Cal(double square)
            {
                return square * square;
            }
        }
        public static void run()
        {
            Calculate cal = new Calculate();
            cal.CalArea(45.02, 49.25);
            Console.WriteLine($"Area of circle is {cal.Cal(20.0)}");
        }
    }
}
