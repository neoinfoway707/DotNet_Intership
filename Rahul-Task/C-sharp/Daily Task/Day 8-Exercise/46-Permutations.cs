using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _46_Permutations
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = Permute(new int[] { 1, 2, 3 });
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join(",", item));
                }
            }
            public static IList<IList<int>> Permute(int[] nums)
            {
                IList<IList<int>> result = new List<IList<int>>();
                List<int> currentList = new List<int>();
                bool[] used = new bool[nums.Length];

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