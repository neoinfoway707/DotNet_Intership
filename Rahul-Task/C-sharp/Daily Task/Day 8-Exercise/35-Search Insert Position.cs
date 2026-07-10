using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _35_Search_Insert_Position
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = SearchInsert(new int[] { 1, 3, 5, 6 }, 2);
                Console.WriteLine(result);
            }
            public static int SearchInsert(int[] nums, int target)
            {
                int low = 0;
                int high = nums.Length - 1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (nums[mid] == target) return mid;
                    else if (nums[mid] > target)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                return low;
            }
        }
    }
}