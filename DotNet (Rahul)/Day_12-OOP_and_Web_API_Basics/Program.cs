using System;

namespace Day_12_OOP_and_Web_API_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========== OOP concepts ===========");
            Console.WriteLine("======= Using Abstraction perfomr task =======");
            OOP_Abstraction.run();
            Console.WriteLine("\n");

            Console.WriteLine("======= Using Encapsulation perfomr task =======");
            OOP_Encapsulation.run();
            Console.WriteLine("\n");

            Console.WriteLine("======= Using Inheritance perfomr task =======");
            OOP_Inheritance.run();
            Console.WriteLine("\n");

            Console.WriteLine("======= Using Polymorphism perfomr task =======");
            OOP_Polymorphism.run();
        }
    }
}
