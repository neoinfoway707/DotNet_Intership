using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _31_Next_Permutation
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] result = { 2, 3, 1 };
                NextPermutation(result);

                Console.Write(string.Join(",", result));
            }

            public static void NextPermutation(int[] nums)
            {
                int i = nums.Length - 2;
                while (i >= 0 && nums[i] >= nums[i + 1])
                    i--;
                if (i >= 0)
                {
                    int j = nums.Length - 1;
                    while (nums[j] <= nums[i])
                        j--;
                    var temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = temp;
                }
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    var temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                    right--;
                }
            }
        }
    }
}