using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _49_Group_Anagrams
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var result = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join(",",item));
                }
            }
            public static IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var result = new List<IList<string>>();
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                for(int i = 0; i < strs.Length; i++)
                {
                    string str = strs[i];
                    char[] chars = str.ToCharArray();
                    Array.Sort(chars);
                    string sortKey = new string(chars);
                    if(!dict.TryGetValue(sortKey, out List<string> group)){
                        group = new List<string>();
                        dict[sortKey]=group;
                        result.Add(group);
                    }
                    group.Add(strs[i]);

                    /*
                    if (dict.ContainsKey(sortKey))
                        dict[sortKey].Add(strs[i]);
                    else
                    {
                        dict[sortKey] = new List<string>();
                        dict[sortKey].Add(strs[i]);
                        result.Add(dict[sortKey]);
                    }*/
                }
                return result;
            }
        }
    }
}