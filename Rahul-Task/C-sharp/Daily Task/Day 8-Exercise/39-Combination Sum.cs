using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _39_Combination_Sum
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
                foreach (var list in result)
                {
                    Console.WriteLine(string.Join(",", list));
                }
            }
            public static IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                IList<IList<int>> result = new List<IList<int>>();
                List<int> currentList = new List<int>();
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

                currentList.Add(candidates[index]);
                CombinationSum(candidates, target - candidates[index], index, currentList, result);
                currentList.RemoveAt(currentList.Count - 1);
                
                CombinationSum(candidates, target, index + 1, currentList, result);

                return result;
            }
        }
    }
}