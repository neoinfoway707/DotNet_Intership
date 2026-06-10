using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _13_Roman_to_Integer
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string roman = "IIVIVLCM";

                int result = RomanToInt(roman);
                Console.WriteLine(result);
            }

            //Fast when small data(small string)
            public static int RomanToInt(string s)
            {
                string symbols = "IVXLCDM";
                int[] values = { 1, 5, 10, 50, 100, 500, 1000 };
                int i = 0;
                int result = 0;
                while (i < s.Length)
                {
                    int current = values[symbols.IndexOf(s[i])];
                    int next = i + 1 < s.Length ? values[symbols.IndexOf(s[i + 1])] : 0;
                    if (current < next)
                        result -= current;
                    else
                        result += current;
                    i++;
                }
                return result;
            }

            //Fast when large data(large string)
            public static int RomanToIntWithDict(string s)
            {
                Dictionary<char, int> RomanNum = new Dictionary<char, int>()
                {
                    {'I', 1}, {'V', 5}, {'X', 10},{'L', 50},
                    {'C', 100}, {'D', 500}, {'M', 1000}
                };
                int i = 0;
                int result = 0;
                while (i < s.Length)
                {
                    int current = RomanNum[s[i]];
                    int next = i + 1 < s.Length ? RomanNum[s[i + 1]] : 0;
                    if (current < next)
                    {
                        result -= current;
                    }
                    else
                    {
                        result += current;
                    }
                    i++;
                }
                return result;
            }
        }
    }
}