using System;
using System.Text.RegularExpressions;

namespace Homework6
{
    /// <summary>
    /// 6. Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
    /// If the last word does not exist, return 0.
    /// Note: A word is defined as a character sequence consists of non-space characters only.
    /// Example:
    /// Input: "Hello World"
    /// Output: 5
    /// </summary>
    class Program
    {
        private const int LINQ_STRATEGY = 1;
        private const int HARD_STRATEGY = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Please input an array separated by <,>: ");
            string inputString = Console.ReadLine();

            Console.WriteLine("Option <1 or 2>: ");
            var optionKey = Console.ReadKey();
            int option = HARD_STRATEGY;

            if (char.IsDigit(optionKey.KeyChar))
            {
                option = int.Parse(optionKey.KeyChar.ToString());
            }

            if (!isAlphaNumeric(inputString))
            {
                Console.WriteLine($"The string <{inputString}> format is invalid");
                Console.ReadKey();

                return;
            }

            IWordCountStrategy countStrategy; 
            switch(option)
            {
                case LINQ_STRATEGY:
                    countStrategy = new WordCountLinq();
                    break;

                case HARD_STRATEGY:
                    countStrategy = new WordCountHard();
                    break;

                default:
                    Console.WriteLine($"Wrong option! Using default <{HARD_STRATEGY}>");
                    countStrategy = new WordCountHard();
                    break;
            }

            int output = countStrategy.GetLastWordCount(inputString);

            Console.WriteLine($"Cleaned up list: {output}");
            Console.ReadKey();
        }

        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}
