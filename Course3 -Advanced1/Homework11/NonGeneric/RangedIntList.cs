using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11.NonGeneric
{
    class RangedIntList : List<int>
    {
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }

        public RangedIntList(int rangeMin, int rangeMax) : base()
        {
            this.RangeMin = rangeMin;
            this.RangeMax = rangeMax;
        }

        public void AddRanged(int element)
        {
            if(element < this.RangeMin || element > this.RangeMax)
            {
                throw new InvalidRangeException<int>(this.RangeMin, this.RangeMax, element);
            }

            base.Add(element);

            Console.WriteLine($"Added {element.ToString()} to the list ... ");
        }
    }
}
