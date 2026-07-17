using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _40_Combination_Sum_II
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
                foreach (var list in result)
                {
                    Console.WriteLine(string.Join(",", list));
                }
            }
            public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                IList<IList<int>> result = new List<IList<int>>();
                List<int> currentList = new List<int>();
                Array.Sort(candidates);
                CombinationSum(candidates, target, 0, currentList, result);
                return result;
            }

            public static IList<IList<int>> CombinationSum(int[] candidates, int target, int index, List<int> currentList, IList<IList<int>> result)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(currentList));
                    return result;
                }
                if (target < 0 || index >= candidates.Length)
                    return result;

                for (int i = index; i < candidates.Length; i++)
                {
                    if (i > index && candidates[i] == candidates[i - 1])
                        continue;

                    currentList.Add(candidates[i]);
                    CombinationSum(candidates, target - candidates[i], i + 1, currentList, result);
                    currentList.RemoveAt(currentList.Count - 1);
                }
                return result;
            }
        }
    }
}