using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _50_Pow_x__n_
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = MyPow(2, -2);
                Console.WriteLine(result);
            }
            public static double MyPow(double x, int n)
            {
                long power = n;
                if( power<0)
                {
                    x = 1 / x;
                    power = -power;
                }
                double result = 1;
                double currentPower = x;
                while(power > 0)
                {
                    if(power%2 == 0)
                    {
                        currentPower *= currentPower;
                        power = power / 2;
                    }
                    else
                    {
                        result = result * currentPower;
                        currentPower *= currentPower;
                        power = power / 2;
                    }
                }
                return result;
            }

            //Using Recursion
           /* public static double MyPow(double x, int n)
            {
                long num = n;
                if (n < 0)
                    return 1 / Pow(x, -num);

                return Pow(x, num);
            }
            private static double Pow(double x, long n)
            {
                if (n == 0) return 1;
                if (n % 2 == 0)
                {
                    var half = Pow(x, n / 2);
                    return half * half;
                }
                else
                {
                    return Pow(x, n - 1) * x;
                }
            }*/
        }
    }
}