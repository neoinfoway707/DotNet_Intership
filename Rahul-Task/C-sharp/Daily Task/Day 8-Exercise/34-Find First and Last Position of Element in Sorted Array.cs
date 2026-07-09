using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _34_Find_First_and_Last_Position_of_Element_in_Sorted_Array
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = SearchRange(new int[] { 1, 2, 4, 4, 5, 6 }, 4);
                Console.WriteLine(string.Join(",", result));
            }
            public static int[] SearchRange(int[] nums, int target)
            {
                int low = 0;
                int high = nums.Length - 1;
                int first = -1;
                int last = -1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (nums[mid] == target)
                    {
                        first = mid;
                        high = mid - 1;
                    }
                    else if (nums[mid] < target)
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
                low = 0; high = nums.Length - 1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (nums[mid] == target)
                    {
                        last = mid;
                        low = mid + 1;
                    }
                    else if (nums[mid] < target)
                        low = mid + 1;
                    else
                        high = mid - 1;
                }

                return new int[] { first, last };
            }
        }
    }
}