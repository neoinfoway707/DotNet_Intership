using System;
using System.Text;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _38_Count_and_Say
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = CountAndSay(5);
                Console.WriteLine(result);
            }
            public static string CountAndSay(int n)
            {
                if (n == 1) return "1";
                var prev = CountAndSay(n - 1);

                StringBuilder result = new StringBuilder();
                int count = 1;

                for (int i = 1; i < prev.Length; i++)
                {
                    if (prev[i] == prev[i - 1])
                        count++;
                    else
                    {
                        result.Append(count);
                        result.Append(prev[i - 1]);
                        count = 1;
                    }
                }
                result.Append(count);
                result.Append(prev[prev.Length - 1]);

                return result.ToString();
            }
          /*public static string CountAndSay(int n)
            {
                if (n == 1) return "1";
                var prev = CountAndSay(n - 1);
                string result = "";
                int count = 1;

                for (int i = 1; i < prev.Length; i++)
                {
                    if (prev[i] == prev[i - 1])
                        count++;
                    else
                    {
                        result += count + "" + prev[i - 1];
                        count = 1;
                    }
                }
                result += count + "" + prev[prev.Length - 1];

                return result;
            }*/
        }
    }
}