using System;
using System.Collections.Generic;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an array separated by <,>: ");
            string inputString = Console.ReadLine();
            string[] unsortedStringArray = inputString.Split(',');

            LinkedList<string> list = new LinkedList<string>(unsortedStringArray);
            
            ReverseTheList(ref list);

            string outputString = string.Join("", list);
            Console.WriteLine($"Reversed list: {outputString}");
            Console.ReadKey();
        }

        private static void ReverseTheList(ref LinkedList<string> list)
        {
            var head = list.First;
            while (head.Next != null)
            {
                var next = head.Next;
                list.Remove(next);
                list.AddFirst(next.Value);
            }
        }

    }
}
