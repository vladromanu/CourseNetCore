using Homework8.Models.Basic;
using Homework8.Models.Interfaces;
using System;

namespace Homework8.Models
{
    class Car : IVehicle
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Producer Producer { get; set; }
        public Guid CarId { get; internal set; }
        public Price Price { get; set; }

        public Car()
        {

        }

        public override string ToString()
        {
            return new string($"{this.Producer} {this.Name} [{this.Year}] {this.Price}");
        }
    }
}
