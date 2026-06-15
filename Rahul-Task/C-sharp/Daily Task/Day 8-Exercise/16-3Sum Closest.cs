using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _16_3Sum_Closest
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] nums = { -1, 2, 1, -1, 5, 1 };

                int target = 4;
                var three = ThreeSumClosest(nums, target);
                Console.WriteLine(three);
            }
            public static int ThreeSumClosest(int[] nums, int target)
            {
                Array.Sort(nums);
                var sum = 0;
                var closest = nums[0] + nums[1] + nums[2];
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        sum = nums[i] + nums[left] + nums[right];
                        if (sum == target)
                            return sum;
                        if (Math.Abs(sum - target) < Math.Abs(closest - target))
                            closest = sum;
                        if (sum > target)
                            right--;
                        else
                            left++;
                    }
                }
                return closest;
            }
        }
    }
}
