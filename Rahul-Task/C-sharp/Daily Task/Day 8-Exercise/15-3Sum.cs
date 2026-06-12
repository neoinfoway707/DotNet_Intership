using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    internal class _15_3Sum
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                int[] nums = { -4, -1, 0, 1, 4 };

                foreach (var triplet in ThreeSum(nums))
                {
                    Console.WriteLine(string.Join(", ", triplet));
                }

                /* int[] nums = { -4, -1, 0, 1, 4 };
                 Array.Sort(nums);
                 List<IList<int>> list = new List<IList<int>>();
                 int sum = 0;//-4 -1 0 1 2
                 for (int i = 0; i < nums.Length; i++)
                 {
                     if (i > 0 && nums[i] == nums[i - 1]) continue;

                     for (int j = i + 1; j < nums.Length - 1; j++)
                     {
                         if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                         for (int k = j + 1; k < nums.Length; k++)
                         {
                             if (k > j + 1 && nums[k] == nums[k - 1]) continue;
                             sum = nums[i] + nums[j] + nums[k];
                             if (sum == 0)
                             {
                                 int[] store = { nums[i], nums[j], nums[k] };
                                 list.Add(new List<int>() { nums[i], nums[j], nums[k] });
                             }
                         }
                     }
                 }
                 foreach (List<int> l in list)
                 {
                     Console.WriteLine(string.Join(", ", l));
                 }*/
            }
            public static IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                List<IList<int>> list = new List<IList<int>>();
                int sum = 0;
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    int left = i + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            list.Add(new List<int> { nums[i], nums[left], nums[right] });
                            left++;
                            while (left < right && nums[left] == nums[left - 1])
                                left++;
                            right--;
                            while (left < right && nums[right] == nums[right + 1] && right + 1 < nums.Length)
                                right--;
                        }
                        else if (sum > 0)
                            right--;
                        else
                            left++;
                    }
                }
                return list;
            }
        }
    }
}
