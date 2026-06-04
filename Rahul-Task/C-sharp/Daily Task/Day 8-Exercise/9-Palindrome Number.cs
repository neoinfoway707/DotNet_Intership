using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _9_Palindrome_Number
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int num = 212212;

                var result = IsPalindrome(num);
                Console.WriteLine(result);
            }

            public static bool IsPalindrome(int x)
            {
                string num = x.ToString();
                int left = 0;
                int right = num.Length - 1;
                while (left < right)
                {
                    if (num[left] != num[right]) return false;
                    left++;
                    right--;
                }
                return true;

                //check number is palindrome or not without converting int to string
                int num2 = x;
                int reversed = 0;
                if (num2 < 0)
                    return false;
                while (num2 > 0)
                {
                    int digit = num2 % 10;
                    num2 /= 10;

                    reversed *= 10;
                    reversed += digit;
                }
                if (reversed == x)
                    return true;
                return false;
            }
        }
    }
}
