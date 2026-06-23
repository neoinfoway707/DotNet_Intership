using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _22_Generate_Parentheses
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int n = 3;
                var result = GenerateParenthesis(n);
                Console.WriteLine(string.Join(",", result));
            }
            public static IList<string> GenerateParenthesis(int num)
            {
                IList<string> list = new List<string>();
                Backtrack(list, "", 0, 0, num);
                return list;
            }

            public static void Backtrack(IList<string> result, string str, int openCount, int closeCount, int num)
            {
                if (str.Length == num * 2)
                {
                    result.Add(str);
                    return;
                }
                if (openCount < num)
                {
                    Backtrack(result, str + "(", openCount + 1, closeCount, num);
                }
                if (closeCount < openCount)
                {
                    Backtrack(result, str + ")", openCount, closeCount + 1, num);
                }
            }
        }
    }
}