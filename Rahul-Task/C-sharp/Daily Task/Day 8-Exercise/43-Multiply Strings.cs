using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _43_Multiply_Strings
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = Multiply("123", "456");
                Console.WriteLine(result);
            }
            public static string Multiply(string num1, string num2)
            {
                if (num1 == "0" || num2 == "0")
                    return "0";
                int n1 = num1.Length;
                int n2 = num2.Length;

                var result = new int[n1 + n2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        int digit1 = num1[n1 - 1 - i] - '0';
                        int digit2 = num2[n2 - 1 - j] - '0';
                        int product = digit1 * digit2;
                        int index = (n1 + n2) - 1 - (i + j);

                        result[index] += product;
                    }
                }
                for (int i = result.Length - 1; i >= 0; i--)
                {
                    if (result[i] >= 10)
                    {
                        var carry = result[i] / 10;
                        result[i] = result[i] % 10;
                        if (i != 0)
                            result[i - 1] += carry;
                    }
                }
                string resultStr = "";
                bool started = false;
                foreach (var item in result)
                {
                    if (item == 0 && !started)
                        continue;
                    started = true;
                    resultStr += (char)(item + '0');
                }
                return resultStr;
            }
        }
    }
}