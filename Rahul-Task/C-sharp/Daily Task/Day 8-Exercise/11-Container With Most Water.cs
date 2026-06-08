using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _11_Container_With_Most_Water
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] height = { 7, 8, 5, 9, 6, 4, 1, 2, 4, 7, 8 };
                int max = MaxArea(height);

                Console.WriteLine(max);
            }
            public static int MaxArea(int[] height)
            {
                int left = 0;
                int right = height.Length - 1;
                int maxArea = 0;

                while (left < right)
                {
                    int area = Math.Min(height[left], height[right]) * (right - left);
                    maxArea = Math.Max(maxArea, area);
                    if (height[left] > height[right])
                        right--;
                    else
                        left++;
                }
                return maxArea;
            }
        }
    }
}
