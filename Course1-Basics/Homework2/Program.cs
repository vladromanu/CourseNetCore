using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an array separated by <,>: ");
            string inputString = Console.ReadLine();

            int majorityNumber;
            try
            {
                majorityNumber = FindMajorityNumber(inputString, true);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.ReadKey();

                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input given");
                Console.ReadKey();

                return;
            }

            Console.WriteLine($"The majority number is: {majorityNumber}");
            Console.ReadKey();
        }

        private static int FindMajorityNumber(string s, bool strict = false)
        {
            int[] unsortedArray = ProcessInputToArray(s);

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                if (!dict.ContainsKey(unsortedArray[i]))
                {
                    dict.Add(unsortedArray[i], 1);
                    continue;
                }

                dict[unsortedArray[i]]++;
            }

            if(false == strict)
            {
                return (int)dict.OrderByDescending(kvp => kvp.Value).First().Key;
            }

            KeyValuePair<int, int> first = dict.OrderByDescending(kvp => kvp.Value).First(); 
            float occurences = (int)first.Value;
            if(occurences < (float)unsortedArray.Length/2)
            {
                throw new ArgumentException("There is no majority element (50%)");
            }

            return (int)first.Key;
        }

        private static int[] ProcessInputToArray(string s)
        {
            string[] unsortedStringArray = s.Split(',');
            return Array.ConvertAll(unsortedStringArray, int.Parse);
        }

    }
}
