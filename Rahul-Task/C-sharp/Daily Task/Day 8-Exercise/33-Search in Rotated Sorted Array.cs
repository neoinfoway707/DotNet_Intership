using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _33_Search_in_Rotated_Sorted_Array
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4);
                Console.WriteLine(result);
            }

            public static int Search(int[] nums, int target)
            {
                int low = 0;
                int high = nums.Length - 1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (nums[mid] == target) return mid;
                    if (nums[low] <= nums[mid])
                    {
                        if (target >= nums[low] && target < nums[mid])
                            high = mid - 1;
                        else
                            low = mid + 1;
                    }
                    else
                    {
                        if (target > nums[mid] && target <= nums[high])
                            low = mid + 1;
                        else
                            high = mid - 1;
                    }

                }
                return -1;
            }
        }
    }
}