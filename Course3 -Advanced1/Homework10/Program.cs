using System;
using System.Collections.Generic;

namespace Homework10
{
    class Program
    {
        // IEnumerable extensions
        // Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.Add unit tests.
        static void Main(string[] args)
        {
            // INT 
            try
            {
                Console.WriteLine("For int ...\n============================");

                IEnumerable<int> ints = new List<int> { 1, 2, 3, 4, 5, 6 };

                Console.WriteLine($"SUM: {ints.Sum()}");
                Console.WriteLine($"PRODUCT: {ints.Product()}");
                Console.WriteLine($"MIN: {ints.Min()}");
                Console.WriteLine($"MAX: {ints.Max()}");
                Console.WriteLine($"AVG: {ints.Average()}");

            }catch (ArgumentException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }catch( DivideByZeroException ex )
            {
                Console.WriteLine($"Average could not be calculated: {ex.Message}");
            }


            // DOUBLE
            try
            {
                Console.WriteLine("\n\nFor double ...\n============================");

                IEnumerable<double> doubles = new List<double> { 1.2, 2.2, 3.2, 4.2, 5.2, 6.2 };

                Console.WriteLine($"SUM: {doubles.Sum()}");
                Console.WriteLine($"PRODUCT: {doubles.Product()}");
                Console.WriteLine($"MIN: {doubles.Min()}");
                Console.WriteLine($"MAX: {doubles.Max()}");
                Console.WriteLine($"AVG: {doubles.Average()}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Average could not be calculated: {ex.Message}");
            }


            // FLOAT 
            try 
            { 
                Console.WriteLine("\n\nFor float ...\n============================");

                IEnumerable<float> floats = new List<float> { 1.1f, 2.1f, 3.1f, 4.1f, 5.1f, 6.1f };

                Console.WriteLine($"SUM: {floats.Sum()}");
                Console.WriteLine($"PRODUCT: {floats.Product()}");
                Console.WriteLine($"MIN: {floats.Min()}");
                Console.WriteLine($"MAX: {floats.Max()}");
                Console.WriteLine($"AVG: {floats.Average()}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Average could not be calculated: {ex.Message}");
            }


            // DECIMAL
            try
            {
                Console.WriteLine("\n\nFor decimal ...\n============================");

                IEnumerable<decimal> decimals = new List<decimal> { 1.5M, 2.5M, 3.5M, 4.5M, 5.5M, 6.5M};

                Console.WriteLine($"SUM: {decimals.Sum()}");
                Console.WriteLine($"PRODUCT: {decimals.Product()}");
                Console.WriteLine($"MIN: {decimals.Min()}");
                Console.WriteLine($"MAX: {decimals.Max()}");
                Console.WriteLine($"AVG: {decimals.Average()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Wrong arguments given: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Average could not be calculated: {ex.Message}");
            }

        }
    }
}