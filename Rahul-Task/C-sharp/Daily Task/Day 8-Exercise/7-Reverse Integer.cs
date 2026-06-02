using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _7_Reverse_Integer
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                //integer number reverse
                int x = 2147483641;
                int reversed = Reverse(x);
                Console.WriteLine(reversed);

                
                //string in integer number reverse
                string s = "-1234567899876543210";
                string sign = "";
                if (!int.TryParse(s.Substring(0, 1), out _))
                {
                    sign = s.Substring(0, 1);
                    s = s.Remove(0, 1);
                }
                string reversedStr = new string(s.Reverse().ToArray());
                reversedStr = reversedStr.TrimStart('0');
                Console.WriteLine(sign + reversed);
            }

            public static int Reverse(int x)
            {
                int reversed = 0;
                while (x != 0)
                {
                    int pop = x % 10;
                    x /= 10;
                    if (reversed > int.MaxValue / 10)
                        return 0;
                    if (reversed < int.MinValue / 10)
                        return 0;
                    reversed = reversed * 10 + pop;
                }
                return reversed;
            }
        }
    }
}
