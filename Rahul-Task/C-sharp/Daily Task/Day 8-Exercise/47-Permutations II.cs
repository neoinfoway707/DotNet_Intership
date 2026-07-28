using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _47_Permutations_II
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = PermuteUnique(new int[] { 3, 3, 0, 3 });
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join(",", item));
                }
            }
            public static IList<IList<int>> PermuteUnique(int[] nums)
            {
                IList<IList<int>> result = new List<IList<int>>();
                List<int> currentList = new List<int>();
                bool[] used = new bool[nums.Length];
                Array.Sort(nums);
                BackTrack(nums, currentList, used, result);
                return result;
            }
            public static void BackTrack(int[] nums, List<int> currentList, bool[] used, IList<IList<int>> result)
            {
                if (currentList.Count == nums.Length)
                {
                    result.Add(new List<int>(currentList));
                    return;
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1] && used[i - 1] == false)
                        continue;
                    if (used[i] == false)
                    {
                        used[i] = true;
                        currentList.Add(nums[i]);
                        BackTrack(nums, currentList, used, result);
                        used[i] = false;
                        currentList.RemoveAt(currentList.Count - 1);
                    }
                }
            }
        }
    }
}