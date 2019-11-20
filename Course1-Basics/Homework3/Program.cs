using System;
using System.Collections.Generic;

namespace Homework3
{
    class Program
    {
        /// <summary>
        /// 3. Count the frequency of chars in a string
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an array separated by <,>: ");
            string inputString = Console.ReadLine();

            Dictionary<char, int> frequencyDictionary = CalculateCharFrequency(inputString);
            foreach (var kvp in frequencyDictionary)
            {
                Console.WriteLine($"Char <{kvp.Key}> appears {kvp.Value} times");
            }

            Console.ReadKey();
        }

        private static Dictionary<char, int> CalculateCharFrequency(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                    continue;
                }

                dict[s[i]]++;
            }

            return dict;
        }
    }
}
