
using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _29_Divide_Two_Integers
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int dividend = 10;
                int divisor = 5;
                var result = Divide(dividend, divisor);
                Console.WriteLine(result);
            }
            public static int Divide(int dividend, int divisor)
            {
                if (dividend == int.MinValue && divisor == -1)
                    return int.MaxValue;

                bool isNegative = (dividend < 0) ^ (divisor < 0);
                long ldividend = Math.Abs((long)dividend);
                long ldivisor = Math.Abs((long)divisor);
                long quotient = 0;

                while (ldividend >= ldivisor)
                {
                    long temp = ldivisor;
                    long multiple = 1;

                    while (ldividend >= (temp << 1))
                    {
                        temp <<= 1;
                        multiple <<= 1;
                    }

                    ldividend -= temp;
                    quotient += multiple;
                }

                return isNegative ? -(int)quotient : (int)quotient;
            }
        }
    }
}