using System;

namespace Day_12_OOP_and_Web_API_Basics
{
    internal class OOP_Inheritance
    {
        public class Animal
        {
            public string Name;

            public string GetAnimal()
            {
                return "Animal class is displayed";
            }
        }
        public class Dog:Animal
        {
            public string DisplayDog()
            {
                base.GetAnimal();
                return $"Name of Anime is {base.Name}";
            }
        }
        public static void run()
        {
            Dog newAnimal = new Dog();
            newAnimal.Name = "Dog";
            Console.WriteLine(newAnimal.DisplayDog());
        }
    }
}
