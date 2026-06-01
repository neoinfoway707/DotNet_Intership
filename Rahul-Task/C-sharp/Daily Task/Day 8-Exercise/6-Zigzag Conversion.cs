using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _6_Zigzag_Conversion
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                string s = "PAYPALISHIRING";
                int numRows = 1;
                string zigzag = Convert(s, numRows);
                Console.WriteLine(zigzag);
            }
            public string Convert(string s, int numRows)
            {
                string[] arr = new string[numRows];
                int currentRow = 0;
                bool goDown = false;
                if(numRows== 1) return s;
                for (int i = 0; i < s.Length; i++)
                {
                    arr[currentRow] += s[i];

                    if (currentRow == 0 || currentRow == numRows - 1)
                    {
                        if (currentRow == numRows - 1)
                            goDown = false;
                        if (currentRow == 0)
                            goDown = true;
                    }
                    if (goDown)
                        currentRow++;
                    else
                        currentRow--;
                }
                string zigzag = "";
                foreach (string str in arr)
                {
                    zigzag += str;
                }
                return zigzag;
            }
        }
    }
}