using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _28_Find_the_Index_of_the_First_Occurrence_in_a_String
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                string needle = "sad";
                string haystack = "sabutsad";
                var result = StrStr(haystack, needle);
                Console.WriteLine(result);
            }
            public static int StrStr(string haystack, string needle)
            {
                for (int i = 0; i <= haystack.Length - needle.Length; i++)
                {
                    if (haystack.Substring(i, needle.Length) == needle)
                        return i;
                }
                return -1;
            }
        }
    }
}
