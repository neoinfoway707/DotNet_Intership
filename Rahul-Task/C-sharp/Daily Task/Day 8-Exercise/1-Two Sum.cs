using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    internal class _1_Two_Sum
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                Console.WriteLine("======= Two Sum =======");
                int[] arr = { 12, 5, 13, 5, 1, 20 };
                int[] res = TwoSum(arr, 13);
                if (res != null)
                {
                    Console.WriteLine("Two Sum: " + res[0] + ", " + res[1]);
                }
                else
                {
                    Console.WriteLine("Not Found.");
                }
            }
            public static int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return null;
            }
        }
    }
}