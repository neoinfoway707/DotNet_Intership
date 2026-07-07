using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _32_Longest_Valid_Parentheses
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = LongestValidParentheses("(()");
                Console.WriteLine(result);
            }
            public static int LongestValidParentheses(string s)
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(-1);
                int length = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        stack.Push(i);
                    }
                    if (s[i] == ')')
                    {
                        stack.Pop();
                        if (stack.Count < 1)
                        {
                            stack.Push(i);
                        }
                        else
                        {
                            length = Math.Max(length, i - stack.Peek());
                        }
                    }
                }
                return length;
                //Using pointers
                /*int right = 0, left = 0;
                int length = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                        left++;
                    else right++;
                    if (left == right) length = Math.Max(length, left + right);
                    else if (right > left)
                    {
                        left = 0;
                        right = 0;
                    }
                }
                left = 0; right = 0;
                for (int i = s.Length-1; i >= 0; i--)
                {
                    if (s[i] == '(')
                        left++;
                    else right++;
                    if (left == right) length = Math.Max(length, left + right);
                    else if (left>right)
                    {
                        left = 0;
                        right = 0;
                    }
                }
                return length;*/
            }
        }
    }
}