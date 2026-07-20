using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _41_First_Missing_Positive
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = FirstMissingPositive(new int[] { -1, 3, 1, 4 });
                Console.WriteLine(result);
            }
            public static int FirstMissingPositive(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int n = nums.Length;
                    int x = nums[i];
                    while (x >= 1 && x <= n)
                    {
                        if (nums[i] == nums[x - 1])
                            break;
                        var temp = nums[i];
                        nums[i] = nums[x - 1];
                        nums[x - 1] = temp;

                        x = nums[i];
                    }
                }
                for(int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != i + 1) return i + 1;
                }
                return nums.Length+1;
            }
        }
    }
}