using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _12_Integer_to_Roman
    {
        public class Solution
        {
            public static void Main(String[] args)
            {
                int num = 3749;
                string result = IntToRoman(num);

                Console.WriteLine(result.ToString());
            }

            /*public static string IntToRoman(int num)
            {
                int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < values.Length; i++)
                {
                    while (num >= values[i])
                    {
                        result.Append(symbols[i]); num -= values[i];
                    }
                }
                return result.ToString();
            }*/

            public static string IntToRoman(int num)
            {
                string symbols = "MDCLXVI";
                int[] values = { 1000, 100, 10, 1 };

                StringBuilder result = new StringBuilder();
                int i = 0;
                while (num > 0)
                {
                    while (num >= values[i])
                    {
                        if (i > 0 && num / values[i] == 4)
                        {
                            result.Append(string.Concat(symbols[i * 2], symbols[i * 2 - 1]));
                            num -= 4 * values[i];
                        }
                        else if (i > 0 && num / values[i] == 9)
                        {
                            result.Append(string.Concat(symbols[i * 2], symbols[i * 2 - 2]));
                            num -= 9 * values[i];
                        }
                        else
                        {
                            if (num / values[i] >= 5)
                            {
                                result.Append(symbols[i * 2 - 1]);
                                num -= 5 * values[i];
                            }
                            else
                            {
                                result.Append(symbols[i * 2]);
                                num -= values[i];
                            }
                        }
                    }
                    i++;
                }
                return result.ToString();
            }
        }
    }
}
