using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    internal class _4_Median_of_Two_Sorted_Arrays
    {
        public class Solution
        {
            static void Main(String[] args)
            {
                int[] arr1 = { 101, 20, 12 };
                int[] arr2 = { 101, 200, 120, 15 };
                Array.Sort(arr1);
                Array.Sort(arr2);
                int[] mergerd = arr1.Concat(arr2).ToArray();
                Array.Sort(mergerd);
                double res = FindMedianSortedArrays(arr1, arr2);
                Console.WriteLine($"Array [{string.Join(", ", mergerd)}] of median is {res}.");
            }

            public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                if (nums1.Length > nums2.Length)
                    return FindMedianSortedArrays(nums2, nums1);

                int totalLeft = (nums1.Length + nums2.Length) / 2;
                int low = 0;
                int high = nums1.Length;
                while (low <= high)
                {
                    int cut1 = (low + high) / 2;
                    int cut2 = totalLeft - cut1;

                    int maxL1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
                    int minR1 = cut1 == nums1.Length ? int.MaxValue : nums1[cut1];

                    int maxL2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
                    int minR2 = cut2 == nums2.Length ? int.MaxValue : nums2[cut2];
                    int maxL = Math.Max(maxL1, maxL2);
                    int minR = Math.Min(minR1, minR2);

                    if (maxL1 <= minR2 && maxL2 <= minR1)
                    {
                        if ((nums1.Length + nums2.Length) % 2 == 0)
                            return (maxL + minR) / 2.0;

                        return minR;
                    }
                    else if (maxL1 > minR2)
                    {
                        high = cut1 - 1;
                    }
                    else
                    {
                        low = cut1 + 1;
                    }
                }
                return 0.0;
            }
            //public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
            //{
            //    int[] merged = nums1.Concat(nums2).ToArray();
            //    Array.Sort(merged);
            //    int left = (merged.Length / 2) - 1;
            //    int right = (merged.Length / 2);

            //    //For calcualte medium for odd length of merged array
            //    if (merged.Length % 2 != 0)
            //        return merged[(merged.Length - 1) / 2];

            //    int i = (left + right) / 2;
            //    return (double)(merged[i] + merged[i + 1]) / 2;
            //}
        }
    }
}
