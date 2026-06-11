using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _14_Longest_Common_Prefix
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string[] strs = { "flower", "flow", "flight" };

                string getPrefix = LongestCommonPrefix(strs);
                Console.WriteLine(getPrefix);
            }
            public static string LongestCommonPrefix(string[] strs)
            {
                int takeStr = strs[0].Length;

                for (int i = 1; i < strs.Length; i++)
                {
                    for (int j = 0; j < takeStr; j++)
                    {
                        if (strs[i].Length == j)
                        {
                            takeStr = j;
                            break;
                        }
                        if (strs[0][j] != strs[i][j])
                            takeStr = j;
                    }
                }
                return strs[0].Substring(0, takeStr); 
            }
        }
    }
}