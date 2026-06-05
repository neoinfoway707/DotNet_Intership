using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _10_Regular_Expression_Matching
    {
        public class solution
        {
            public static void Main(string[] args)
            {
                string s = "aab";
                string p = "c*a*b";
                bool result = IsMatch(s, p);
                Console.WriteLine(result);
            }
            public static bool IsMatch(string s, string p)
            {
                string row = s;
                string column = p;
                bool[,] dp = new bool[row.Length + 1, column.Length + 1];
                dp[0, 0] = true;


                for (int j = 2; j <= column.Length; j++)
                {
                    if (column[j - 1] == '*')
                        dp[0, j] = dp[0, j - 2];
                }
                for (int i = 1; i <= row.Length; i++)
                {
                    for (int j = 1; j <= column.Length; j++)
                    {
                        //Rule 2 3 
                        if (column[j - 1] == '*')
                        {
                            dp[i, j] = dp[i, j - 2];
                            if (row[i - 1] == column[j - 2] || column[j - 2] == '.')
                            {
                                dp[i, j] = dp[i, j] || dp[i - 1, j];
                            }
                        }
                        //Rule 1
                        else
                        {
                            if (row[i - 1] == column[j - 1] || column[j - 1] == '.')
                            {
                                dp[i, j] = dp[i - 1, j - 1];
                            }
                        }
                    }
                }

                Console.Write("      _ ");
                for (int j = 0; j < p.Length; j++)
                {
                    Console.Write(p[j] + " ");
                }
                Console.WriteLine("\n-------------------");

                for (int i = 0; i <= s.Length; i++)
                {
                    if (i == 0) Console.Write("_ |   ");
                    else Console.Write(s[i - 1] + " |   ");

                    for (int j = 0; j <= p.Length; j++)
                    {
                        Console.Write((dp[i, j] ? "T" : "F") + " ");
                    }
                    Console.WriteLine();
                }

                return dp[s.Length, p.Length];
            }
        }
    }
}