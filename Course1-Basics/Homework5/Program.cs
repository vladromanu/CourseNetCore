using System;
using System.Collections.Generic;

namespace Homework5
{
    class Program
    {
        /// <summary>
        /// 5. Write code to remove duplicates from an unsorted linked list.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an array separated by <,>: ");
            string inputString = Console.ReadLine();
            string[] unsortedStringArray = inputString.Split(',');

            // Starting from the linked list 
            LinkedList<string> list = new LinkedList<string>(unsortedStringArray);

            list = RemoveDuplicates(list);

            string outputString = string.Join("", list);
            Console.WriteLine($"Cleaned up list: {outputString}");
            Console.ReadKey();
        }

        private static LinkedList<string> RemoveDuplicates(LinkedList<string> list)
        {
            return new LinkedList<string>(new HashSet<string>(list));
        }

    }
}
