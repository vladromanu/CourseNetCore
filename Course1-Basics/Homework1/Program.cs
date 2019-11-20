using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        /// <summary>
        /// 1. Write a function to remove duplicate characters from String
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string inputString = Console.ReadLine();

            string outputString = RemoveDuplicates(inputString);
            Console.WriteLine("Output: " + outputString);

            Console.ReadKey();
        }
        
        private static string RemoveDuplicates(string s)
        {
            var unique = new HashSet<char>(s);
            return string.Join("", unique);
        }
    }
}
