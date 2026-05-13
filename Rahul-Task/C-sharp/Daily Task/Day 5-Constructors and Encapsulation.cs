using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task
{
    internal class Day_5_Constructors_and_Encapsulation
    {
        //Create Class with constructor and encapsulation(get and set properties).
        class Person
        {
            private string name;
            private int age;
            public Person(String name, int age)
            {
                this.name = name;
                this.age = age;
            }

            //Display Data with get and set properties.
            public String Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
            public int Age
            {
                get { return this.age; }
                set { this.age = value; }
            }

            //display the data using Methods
            public String GetData()
            {
                return $"Name: {name}, Age: {age} ";
            }
            static void Main(String[] args)
            {
                //Create an object of class Person
                Person person = new Person("M.S. Dhoni", 44);
                //Display the data using Methods
                Console.WriteLine("\n\nAdded Data with class constructor: \n" + person.GetData());

                //Set new values using get and set properties
                person.Name = "Arvind Patel";
                person.Age = 31;

                //Display the data using get and set properties
                Console.WriteLine("\nAdded Data with get and set properties:");
                Console.WriteLine($"Name: {person.name}, Age: {person.Age}");
            }
        }
    }
}