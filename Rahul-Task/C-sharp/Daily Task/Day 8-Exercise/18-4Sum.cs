using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _18_4Sum
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                int[] nums = { 1000000000, 1000000000, 1000000000, 1000000000 };
                int target = -294967296;
                var result = FourSum(nums, target);
                foreach (var l in result)
                {
                    Console.WriteLine(string.Join(", ", l));
                }
            }
            public static IList<IList<int>> FourSum(int[] nums, int target)
            {
                List<IList<int>> list = new List<IList<int>>();

                long sum = 0;
                Array.Sort(nums);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) continue;

                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        int left = j + 1;
                        int right = nums.Length - 1;

                        if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                        while (left < right)
                        {
                            sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                            if (sum == target)
                            {
                                list.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                                left++;
                                while (left < right && nums[left] == nums[left - 1])
                                    left++;
                                right--;
                                while (left < right && nums[right] == nums[right + 1])
                                    right--;
                            }
                            else if (sum > target)
                                right--;
                            else
                                left++;
                        }
                    }
                }
                return list;
            }
        }
    }
}
