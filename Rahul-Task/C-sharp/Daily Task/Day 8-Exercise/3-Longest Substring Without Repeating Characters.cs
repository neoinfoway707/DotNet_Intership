using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    internal class _3_Longest_Substring_Without_Repeating_Characters
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string str = "asqasdsd";
                Console.WriteLine($"String {str} in longest substring length is {LengthOfLongestSubstring(str)}.");

            }
            public static int LengthOfLongestSubstring(string s)
            {
                string substring = s;
                HashSet<char> map = new HashSet<char>();

                int max = 0;
                int start = 0;
                for (int i = 0; i < substring.Length; i++)
                {
                    while (map.Contains(substring[i]))
                    {
                        map.Remove(substring[start]);
                        start = start + 1;
                    }
                    map.Add(substring[i]);
                    max = Math.Max(max, i - start + 1);
                }
                return max;
            }
        }
    }
}
