using Homework11.Generic;
using Homework11.NonGeneric;
using System;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Range Exceptions
            // Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.It should hold error message and a range definition[start … end].
            // Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> 
            // by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

            // INT
            Console.WriteLine("Inseting ints...... \n");
            try
            {
                GenericRangedList<int> list = new GenericRangedList<int>(0, 1000);
                list.AddRanged(1);
                list.AddRanged(2);
                list.AddRanged(3);
                list.AddRanged(4);

                list.AddRanged(9999);
                list.AddRanged(-9999);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine($"InvalidRangeException thrown: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }


            // DATE TIME
            Console.WriteLine("\n\nInseting date times ...... \n");
            try
            {
                GenericRangedList<DateTime> listDates = new GenericRangedList<DateTime>(DateTime.Now, new DateTime(2020, 01, 01, 00, 00, 00));

                listDates.AddRanged(DateTime.Now);
                listDates.AddRanged(new DateTime(2019, 12, 5, 12, 00, 00));
                listDates.AddRanged(new DateTime(2019, 12, 7, 12, 00, 00));
                listDates.AddRanged(new DateTime(2019, 12, 15, 12, 00, 00));

                listDates.AddRanged(DateTime.MinValue);
                listDates.AddRanged(DateTime.MaxValue);
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine($"InvalidRangeException thrown: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }

            // Uncomment this for the non-generic ranged lists
            //nonGeneric();

        }

        private static void nonGeneric()
        {
            // INT
            try
            {
                RangedIntList list = new RangedIntList(0, 1000);
                list.AddRanged(1);
                list.AddRanged(2);
                list.AddRanged(3);
                list.AddRanged(4);

                list.AddRanged(9999);
                list.AddRanged(-9999);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine($"InvalidRangeException thrown: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }

            // DATE TIME
            try
            {
                DateTimeRangedList listDates = new DateTimeRangedList(DateTime.Now, new DateTime(2020, 01, 01, 00, 00, 00));

                listDates.Add(DateTime.Now);
                listDates.Add(DateTime.Today);
                listDates.Add(new DateTime(2019, 12, 5, 12, 00, 00));
                listDates.Add(new DateTime(2019, 12, 7, 12, 00, 00));
                listDates.Add(new DateTime(2019, 12, 15, 12, 00, 00));

                listDates.Add(DateTime.MinValue);
                listDates.Add(DateTime.MaxValue);
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine($"InvalidRangeException thrown: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }

        }
    }
}