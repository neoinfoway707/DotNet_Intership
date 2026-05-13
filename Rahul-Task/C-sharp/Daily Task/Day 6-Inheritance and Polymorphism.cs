using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task
{
    internal class Day_6_Inheritance_and_Polymorphism
    {
        static void Main(string[] args)
        {
            // Create an object of the Dog class
            Dog dog = new Dog("Dog", "Animal");
            // Call the Disp method of the Dog class
            dog.Disp();
            // Create an object of the Cat class
            Cat cat = new Cat("Cat", "Animal");
            // Call the makeSound method of both classes
            Console.WriteLine("\n======= Calling makeSound method of Dog class =======");
            dog.makeSound();
            Console.WriteLine("\n======= Calling makeSound method of Cat class =======");
            cat.makeSound();
        }
        // Base class
        class Animal
        {
            protected string animName;
            public Animal(string name)
            {
                this.animName = name;
            }
            // Method of animal class
            protected void Disp()
            {
                Console.WriteLine("Animal class name: " + animName);
            }
            // Virtual method of animal class and override it in derived class
            public virtual void makeSound()
            {
                Console.WriteLine("Animal makes a sound, animal name: " + animName);
            }
        }
        // Derived class 1
        class Dog : Animal
        {
            public string name;
            public Dog(string name, string animalType) : base(animalType)
            {
                this.name = name;
            }
            // Override the Disp method of the base class
            public void Disp()
            {
                base.Disp();
                Console.WriteLine("Dog class name: " + name + ", Animal class name: " + base.animName);
            }
            // Override the makeSound method of the base class
            public override void makeSound()
            {
                // Call the makeSound method of the base class
                base.makeSound();
                Console.WriteLine("Dog barks, dog name: " + name);
            }
        }
        // Derived class 2
        class Cat : Animal
        {
            public string name;
            public Cat(string name, string animalType) : base(animalType)
            {
                this.name = name;
            }
            // Override the makeSound method of the base class
            public override void makeSound()
            {
                // Call the makeSound method of the base class
                base.makeSound();
                Console.WriteLine("Cat meows, cat name: " + name);
            }
        }
    }
}