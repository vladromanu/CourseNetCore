using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11.NonGeneric
{
    class DateTimeRangedList : List<DateTime>
    {
        public DateTime RangeMin { get; set; }
        public DateTime RangeMax { get; set; }

        public DateTimeRangedList(DateTime rangeMin, DateTime rangeMax) : base()
        {
            this.RangeMin = rangeMin;
            this.RangeMax = rangeMax;
        }

        public void AddRanged(DateTime element)
        {
            if (element < this.RangeMin || element > this.RangeMax)
            {
                throw new InvalidRangeException<DateTime>(this.RangeMin, this.RangeMax, element);
            }

            base.Add(element);

            Console.WriteLine($"Added {element.ToString()} to the list ... ");
        }
    }
}
