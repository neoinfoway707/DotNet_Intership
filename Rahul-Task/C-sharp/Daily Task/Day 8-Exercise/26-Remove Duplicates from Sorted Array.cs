using System;
using System.Linq;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _26_Remove_Duplicates_from_Sorted_Array
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] nums = { 1, 2 };
                var result = RemoveDuplicates(nums);
                Console.WriteLine(result);
            }
        }
        public static int RemoveDuplicates(int[] nums)
        {
            int slow = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[slow])
                    continue;
                else
                {
                    slow++;
                    nums[slow] = nums[i];
                }
            }
            return slow + 1;
        }
    }
}