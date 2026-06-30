using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _27_Remove_Element
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] nums = { 1, 2, 1, 4, 1, 3, 1 };
                var result = RemoveElement(nums, 1);
                Console.WriteLine(result);
            }
            public static int RemoveElement(int[] nums, int val)
            {
                int count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == val)
                        continue;
                    else
                    {
                        nums[count] = nums[i];
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
