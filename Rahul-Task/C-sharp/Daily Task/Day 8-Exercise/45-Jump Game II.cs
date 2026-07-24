using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _45_Jump_Game_II
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = Jump(new int[] { 2, 3, 1, 1, 4 });
                Console.WriteLine(result);
            }
            public static int Jump(int[] nums)
            {
                int currentEnd = 0, farthest = 0, jumps = 0;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    farthest = Math.Max(farthest, i + nums[i]);
                    if (i == currentEnd)
                    {
                        jumps++;
                        currentEnd = farthest;
                    }
                }
                return jumps;
            }
        }
    }
}
