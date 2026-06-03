using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _8_String_to_Integer__atoi_
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string str = "2147483646";
                int result = MyAtoi(str);
                Console.WriteLine(result);
            }

            public static int MyAtoi(string s)
            {
                char? sign = null;
                s = s.TrimStart();
                if (s == null || s.Length == 0) return 0;
                int i = 0;
                int result = 0;
                if (s[0] == '-' || s[0] == '+')
                {
                    sign = s[0];
                    i++;
                }

                while (i < s.Length)
                {
                    if (s[i] == ' ')
                        break;
                    else if (s[i] < '0' || s[i] > '9')
                        break;
                    else
                    {
                        int digit = s[i] - '0';

                        if (result > int.MaxValue / 10 || 
                            (result == int.MaxValue/ 10 && digit > 7))
                        {
                            result = sign == '-' ? int.MinValue : int.MaxValue;
                            break;
                        }
                        result *= 10;

                        result += digit;
                        i++;
                    }
                }
                if (sign == '-' && result != int.MinValue)
                    result = -result;
                return result;
            }
        }
    }
}