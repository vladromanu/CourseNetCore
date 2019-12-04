using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11.Generic
{
    class GenericRangedList<T> : List<T>
    {
        public T RangeMin { get; set; }
        public T RangeMax { get; set; }

        public GenericRangedList(T rangeMin, T rangeMax) : base()
        {
            this.RangeMin = rangeMin;
            this.RangeMax = rangeMax;
        }

        public void AddRanged<T>(T element) where T : IComparable
        {
            if( element.CompareTo(this.RangeMax) > 0 || element.CompareTo(this.RangeMin) < 0 )
            {
                throw new InvalidRangeException<T>((dynamic)this.RangeMin, (dynamic)this.RangeMax, (dynamic) element);
            }

            this.Add((dynamic)element);

            Console.WriteLine($"Added {element} to the list ... ");
        }
    }
}
