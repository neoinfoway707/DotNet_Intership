using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task
{
    internal class Day_4_Classes_and_Objects
    {
        public class car
        {
            public string brand;
            public string model;
            public string year;
            public string display()
            {
                return $"Brand: {brand}, Model: {model}, Year: {year}";
            }
            public car()
            {
                year = "2025";
            }
        }
        static String display(car myCar)
        {
            return $"Brand: {myCar.brand}, Model: {myCar.model}, Year: {myCar.year}";
        }
        static void Main(string[] args)
        {
            // Create an instance of the car class
            Console.WriteLine("============= Add and Display car details in car class =============");
            car myCar = new car();
            myCar.brand = "Toyota";
            myCar.model = "Camry";
            myCar.year = "2020";
            Console.WriteLine(myCar.display());
            
            car anotherCar = new car();
            anotherCar.brand = "Honda";
            anotherCar.model = "Civic";
            Console.WriteLine(anotherCar.display());

            Console.WriteLine("============== Display car details outside the class method ============");
            car newCar = new car();
            newCar.brand = "Ford";
            newCar.model = "Mustang";
            newCar.year = "2021";
            Console.WriteLine(display(newCar));
            
            car latestCar = new car();
            latestCar.brand = "Rolls-Royce";
            latestCar.model = "Droptail";
            latestCar.year = "2024";
            Console.WriteLine(display(latestCar));
        }      
    }
}
