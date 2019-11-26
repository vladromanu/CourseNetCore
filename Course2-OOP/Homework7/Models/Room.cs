using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Models
{
    class Room
    {
        private string name;
        private Rate rate;
        private byte adults;
        private byte children;

        public Rate Rate { get => rate; set => rate = value; }
        public byte Adults { get => adults; set => adults = value; }
        public byte Children { get => children; set => children = value; }
        public string Name { get => name; set => name = value; }

        public Rate GetPriceForDays(int numberOfDays) => new Rate()
        {
            Amount = numberOfDays * Rate.Amount,
            Currency = Rate.Currency
        };

        public string Print
        {
            get
            {
                return $"RoomName: {Name} adults:{Adults} children:{Children} rate:{Rate}";
            }
        }
        public override string ToString()
        {
            return this.Print;
        }
    }
}
