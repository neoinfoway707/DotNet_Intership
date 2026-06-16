using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _17_Letter_Combinations_of_a_Phone_Number
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string digits = "23";
                var result = LetterCombinations(digits);
                Console.WriteLine(string.Join(",", result));
            }
            public static IList<string> LetterCombinations(string digits)
            {
                string[] phone = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
                List<string> result = new List<string>();

                void Backtrack(string current, int index)
                {
                    if (index == digits.Length)
                    {
                        result.Add(current);
                        return;
                    }
                    string letters = phone[digits[index] - '0'];
                    foreach (char letter in letters)
                    {
                        Backtrack(current + letter, index + 1);
                    }
                }
                Backtrack("", 0);
                return result;
            }
        }
    }
}