using System;

namespace C_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Different Types of Variables
            string varString = "This is String";
            int varInt = 7;
            double varDouble = 77.77545454564564654D;
            bool varBool = false;
            long varLong = 789456123L;
            float varFloat = 78.01F;
            char varChar = 'D';

            //Print Variables with contation and interpolation
            Console.WriteLine("String variable: " + varString);
            Console.WriteLine("Integer variable: " + varInt);
            Console.WriteLine("Double variable: " + varDouble);
            Console.WriteLine($"Boolean variable: {varBool}");
            Console.WriteLine($"Long variabel: {varLong}");
            Console.WriteLine($"Float variable: {varFloat}");
            Console.WriteLine($"Char variable: {varChar}");


            //Type Casting
            Console.WriteLine("\n\n============= Type Casting =============\n");
            double typeCastInt = varInt;
            long tyeCastDouble = (long)varDouble;
            Console.WriteLine("Implicit Type Casting - Inteher to Double: " + typeCastInt);
            Console.WriteLine("Explicit Type Casting - Double to Long: " + tyeCastDouble);
            Console.WriteLine("\n\nUsing Methods to Type Cast variable:");
            Console.WriteLine("Integer To String: " + varInt.ToString());
            Console.WriteLine("Long To Double: " + Convert.ToDouble(varLong));
            Console.WriteLine("Float To Integer: " + Convert.ToInt32(varFloat));
            Console.WriteLine("Double To String: " + Convert.ToString(varDouble));
            Console.WriteLine("Char To String: " + Convert.ToString(varChar));


            //Arithmetic Operators
            Console.WriteLine("\n\n============= Arithmetic Operators =============\n");
            Console.WriteLine("Original Integer Value: " + varInt);
            varInt = 7 + 7;
            Console.WriteLine("7 + 7 Arithmetic (+) Operator: " + varInt);
            varInt = 7 - 7;
            Console.WriteLine("7 - 7 Arithmetic (-) Operator: " + varInt);
            varInt = 7 * 7;
            Console.WriteLine("7 * 7 Arithmetic (*) Operator: " + varInt);
            varInt = 7 / 7;
            Console.WriteLine("7 / 7 Arithmetic (/) Operator: " + varInt);
            varInt = 14 % 2;
            Console.WriteLine("14 % 7Arithmetic (%) Operator: " + varInt);


            //Assignment Operators
            varInt = 7;
            Console.WriteLine("\n\n============= Assignment Operators =============\n");
            Console.WriteLine("Original Integer Value: " + varInt);
            varInt += 7;
            Console.WriteLine("+= 7 Assignemnt (+=) Operator: " + varInt);
            varInt -= 7;
            Console.WriteLine("-= 7 Assignemnt (-=) Operator: " + varInt);
            varInt *= 2;
            Console.WriteLine("*= 2 Assignemnt (*=) Operator: " + varInt);
            varInt /= 2;
            Console.WriteLine("/= 2 Assignemnt (/=) Operator: " + varInt);
            varInt %= 2;
            Console.WriteLine("%= 7 Assignemnt (%=) Operator: " + varInt);


            //Comparision Operators
            Console.WriteLine("\n\n============= Comparision Operators =============\n");
            Console.WriteLine($"7 == 7 Comparision (==) Operator: {7 == 7}");
            Console.WriteLine($"7 != 7 Comparision (!=) Operator: {7 != 7}");
            Console.WriteLine($"7 > 7 Comparision (>) Operator: {7 > 7}");
            Console.WriteLine($"7 < 7 Comparision (<) Operator: {7 < 7}");
            Console.WriteLine($"7 >= 7 Comparision (>=) Operator: {7 >= 7}");
            Console.WriteLine($"7 <= 7 Comparision (<=) Operator: {7 <= 7}");

            //Logical Operators
            Console.WriteLine("\n\n============= Logical Operators =============\n");
            Console.WriteLine("(7 == 7) Logical (==) Operator: {0}", (7 == 7));
            Console.WriteLine("(7 != 7) Logical (!=) Operator: {0}", (7 != 7));
            Console.WriteLine("(7 <=7 && 7 >= 7) Logical (&&)Operator: {0}", (7 <= 7 && 7 >= 7));
            Console.WriteLine("(7 < 7 || 7 > 7) Logical (||)Oprator: {0}", (7 < 7 || 7 > 7));
        }
    }
}
