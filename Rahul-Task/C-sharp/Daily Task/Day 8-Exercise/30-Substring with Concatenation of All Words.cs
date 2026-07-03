using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Security.Principal;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _30_Substring_with_Concatenation_of_All_Words
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                IList<int> result = FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
                foreach (int index in result)
                {
                    Console.WriteLine(index);
                }
            }
            public static IList<int> FindSubstring(string s, string[] words)
            {
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    if (wordsCount.ContainsKey(word))
                        wordsCount[word]++;
                    else
                        wordsCount[word] = 1;
                }
                var wordLength = words[0].Length;
                var totalLength = wordLength * words.Length;
                var result = new List<int>();
                for (int i = 0; i < wordLength; i++)
                {
                    Dictionary<string, int> checkWord = new Dictionary<string, int>();
                    int left = i, count = 0;

                    for (int j = i; j <= s.Length - wordLength; j += wordLength)
                    {
                        var word = s.Substring(j, wordLength);
                        if (wordsCount.ContainsKey(word))
                        {
                            if (checkWord.ContainsKey(word)) checkWord[word]++;
                            else checkWord[word] = 1;
                            count++;
                            while (checkWord[word] > wordsCount[word])
                            {
                                var removeword = s.Substring(left, wordLength);
                                checkWord[removeword]--;
                                count--;
                                left += wordLength;
                            }
                            if (count == words.Length)
                                result.Add(left);
                        }
                        else
                        {
                            checkWord.Clear();
                            count = 0;
                            left = j + wordLength;
                        }
                    }
                }
                return result;
            }
        }
    }
}