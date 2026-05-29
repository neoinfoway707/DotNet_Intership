using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _5_Longest_Palindromic_Substring
    {
        public class Solution
        {

            public static void Main(string[] args)
            {
                string str = "abcbaabba";
                string palindrome = LongestPalindrome(str);


                Console.WriteLine($"{palindrome}");
            }
            public static string LongestPalindrome(string s)
            {
                string store = "";

                for (int i = 0; i < s.Length; i++)
                {
                    string odd = SubString(s, i, i);
                    string even = SubString(s, i, i + 1);
                    if (odd.Length > store.Length) store = odd;
                    if (even.Length > store.Length) store = even;

                }
                return store;
            }
            public static string SubString(string str, int left, int right)
            {
                while (left >= 0 && right < str.Length && str[left] == str[right])
                {
                    left--;
                    right++;
                }
                return str.Substring(left + 1, right - left - 1);
            }
        }
    }
}



