using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _20_Valid_Parentheses
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string str = "{[]{}}{}";
                bool result = IsValid(str);
                Console.WriteLine(result);
            }
            public static bool IsValid(string s)
            {
                string open = "([{";
                string close = ")]}";
                Stack<Char> stack = new Stack<Char>();
                foreach (char c in s)
                {
                    for (int i = 0; i < open.Length; i++)
                    {
                        if (c == open[i])
                            stack.Push(c);
                        if (c == close[i])
                        {
                            if (stack.Count == 0 || stack.Peek() != open[i])
                                return false;
                            stack.Pop();
                        }
                    }
                }
                //return stack.Count == 0;
                return stack.Count == 0 ? true : false;
            }
        }
    }
}