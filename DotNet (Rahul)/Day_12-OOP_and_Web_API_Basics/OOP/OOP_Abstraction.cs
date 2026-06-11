using System;

namespace Day_12_OOP_and_Web_API_Basics
{
    internal class OOP_Abstraction
    {
        abstract class Car
        {
            public abstract void display();
        }
        interface ICar
        {
            string Intro();
        }
        class Vehicle : Car, ICar
        {
            public override void display()
            {
                Console.WriteLine("Using Abstract display this Message.");
            }
            public string Intro()
            {
                return "New Car issued Successfully.";
            }
        }
        public static void run()
        {
            Vehicle IssCar = new Vehicle();
            IssCar.display();
            Console.WriteLine($"Using interface retrive string :{IssCar.Intro()}");
        }
    }
}

