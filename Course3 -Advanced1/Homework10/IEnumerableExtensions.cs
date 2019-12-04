using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework10
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> set) where T : IConvertible, IComparable
        {
            if (set.Count() == 0)
            {
                throw new ArgumentException("Empty input set!");
            }

            T result = (dynamic)0;
            foreach (T element in set)
            {
                result += (dynamic)element;
            }
            return result;
        }

        public static T Product<T>(this IEnumerable<T> set) where T : IConvertible, IComparable
        {
            if (set.Count() == 0)
            {
                throw new ArgumentException("Empty input set!");
            }

            T result = (dynamic)1;
            foreach (T element in set)
            {
                result *= (dynamic)element;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> set) where T : IConvertible, IComparable
        {
            if (set.Count() == 0)
            {
                throw new ArgumentException("Empty input set!");
            }

            T min = set.First();
            for (int i = 1; i < set.Count(); i++) // from index 1 
            {
                if (set.ElementAt(i).CompareTo(min) < 0)
                {
                    min = set.ElementAt(i);
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> set) where T : IConvertible, IComparable
        {
            if (set.Count() == 0)
            {
                throw new ArgumentException("Empty input set!");
            }

            T max = set.First();
            for (int i = 1; i < set.Count(); i++) 
            {
                if (set.ElementAt(i).CompareTo(max) > 0) // from index 1 
                {
                    max = set.ElementAt(i);
                }
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> set) where T : IConvertible, IComparable
        {
            return (dynamic)set.Sum() / set.Count();
        }
    }    
}
