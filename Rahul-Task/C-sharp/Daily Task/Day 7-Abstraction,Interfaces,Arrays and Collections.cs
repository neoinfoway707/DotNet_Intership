using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace C_sharp.Daily_Task
{
    internal class Day_7_Abstraction_Interfaces_Arrays_and_Collections
    {
        //create abstracr class shape for getArea method
        abstract class Shape
        {
            public abstract double GetArea();
        }

        //create circle class for calculate area of circle
        class Circle : Shape
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        //create rectangle class for calculate area of rectangle
        class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double GetArea()
            {
                return Width * Height;
            }
        }
        //create student class for store student names and marks
        class StudeName
        {
            string[] studentNames = new string[5];
            //create method for store student names and marks and calculate average marks
            public void storeStudeNames()
            {
                //store student names in array
                for (int i = 0; i < studentNames.Length; i++)
                {
                    Console.Write($"Enter name of student {i + 1}: ");
                    studentNames[i] = Console.ReadLine();
                }
                //store marks in List and student names and marks in Dictionary
                Dictionary<string, double> studentMarks = new Dictionary<string, double>();
                List<double> marks = new List<double>();
                foreach (string name in studentNames)
                {
                    //store marks in List
                    Console.Write($"Enter marks for {name}: ");
                    double mark = Convert.ToDouble(Console.ReadLine());
                    marks.Add(mark);

                    //store student names and marks in dictionary
                    studentMarks[name] = mark;
                }
                //calculate average marks
                double averageMarks = marks.Average();
                Console.WriteLine($"\nAverage Marks: {averageMarks}");

                //display student names and marks
                foreach (string name in studentNames)
                {
                    Console.WriteLine($"{name} → {studentMarks[name]}");
                }
            }
        }
        static void Main(string[] args)
        {
            //get radius for circle and call calculate area of circle
            Console.Write("Enter radius for Circle: ");
            double circleRadius = Convert.ToDouble(Console.ReadLine());
            Shape circle = new Circle(circleRadius);

            //get width and height for rectangle and call calculate area of rectangle
            Console.Write("Enter width for Rectangle: ");
            double rectangleWidth = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter height for Rectangle: ");
            double rectangleHeight = Convert.ToDouble(Console.ReadLine());
            Shape rectangle = new Rectangle(rectangleWidth, rectangleHeight);

            //display area of circle and rectangle
            Console.WriteLine("\n======= Area of Circle and Rectangle =======");
            Console.WriteLine("Circle Area: " + circle.GetArea());
            Console.WriteLine("Rectangle Area: " + rectangle.GetArea());

            //create object of student class to store student details
            StudeName studName = new StudeName();
            studName.storeStudeNames();
        }
    }
}