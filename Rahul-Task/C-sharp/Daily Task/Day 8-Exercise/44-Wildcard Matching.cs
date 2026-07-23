using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _44_Wildcard_Matching
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = IsMatch("aa", "*");
                Console.WriteLine(result);
            }
            public static bool IsMatch(string s, string p)
            {
                string row = s;
                string column = p;
                bool[,] dp = new bool[row.Length + 1, column.Length + 1];
                dp[0, 0] = true;

                for (int j = 1; j <= column.Length; j++)
                {
                    if (column[j - 1] == '*')
                        dp[0, j] = dp[0, j - 1];
                }
                for (int i = 1; i <= row.Length; i++)
                {
                    for (int j = 1; j <= column.Length; j++)
                    {
                        if (p[j - 1] == '?' || p[j - 1] == s[i - 1])
                            dp[i, j] = dp[i - 1, j - 1];
                        else if (p[j - 1] == '*')
                            dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                        else
                            dp[i, j] = false;
                    }
                }
                return dp[s.Length, p.Length];
                //return Match(s, p, 0, 0);
            }
            /* public static bool Match(string s, string p, int i, int j)
             {
                 if (i == s.Length && j == p.Length)
                     return true;
                 if (i == s.Length)
                 {
                     for (int n = j; n < p.Length; n++)
                     {
                         if (p[n] != '*')
                             return false;
                     }
                     return true;
                 }
                 if (j == p.Length)
                     return false;

                 if (p[j] == '?' || p[j] == s[i])
                     return Match(s, p, i + 1, j + 1);
                 else if (p[j] == '*')
                     return Match(s, p, i, j + 1) || (i < s.Length && Match(s, p, i + 1, j));
                 else
                     return false;
             }*/
        }
    }
}