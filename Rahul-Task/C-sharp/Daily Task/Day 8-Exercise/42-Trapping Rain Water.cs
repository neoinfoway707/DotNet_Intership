using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _42_Trapping_Rain_Water
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = Trap(new int[] { 4, 2, 0, 3, 2, 5 });
                Console.WriteLine(result);
            }
            public static int Trap(int[] height)
            {
                int left = 0, right = height.Length - 1;
                int leftMax = 0, rightMax = 0;
                int totalWater = 0;
                while (left <= right)
                {
                    if (leftMax < rightMax)
                    {
                        leftMax = Math.Max(leftMax, height[left]);
                        totalWater += leftMax - height[left];
                        left++;
                    }
                    else
                    {
                        rightMax = Math.Max(rightMax, height[right]);
                        totalWater += rightMax - height[right];
                        right--;
                    }
                }
                return totalWater;

               /* int[] leftMax = new int[height.Length];
                int[] rightMax = new int[height.Length];
                int waterUnit = 0;

                for (int i = 0; i < height.Length; i++)
                {
                    if (i > 0)
                        leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
                    else
                        leftMax[i] = height[i];

                }
                for (int i = height.Length - 1; i >= 0; i--)
                {
                    if (i < height.Length - 1)
                        rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
                    else
                        rightMax[i] = height[i];
                }
                for (int i = 0; i < height.Length; i++)
                {
                    waterUnit += Math.Min(leftMax[i], rightMax[i]) - height[i];
                }
                return waterUnit;*/
            }
        }
    }
}
