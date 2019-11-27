using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Types
{
    class Room
    {
        // Just Props 
        public Rate Rate { get; set; }
        public byte Adults { get; set; }
        public byte Children { get; set; }
        public string Name { get; set; }

        public Rate GetPriceForDays(int numberOfDays) => new Rate()
        {
            Amount = numberOfDays * Rate.Amount,
            Currency = Rate.Currency
        };

        public string Print
        {
            get
            {
                return $"RoomName: {this.Name} Adults:{this.Adults} Children:{this.Children} {this.Rate}";
            }
        }
        public override string ToString()
        {
            return this.Print;
        }
    }
}
