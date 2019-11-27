using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Car : IVehicle
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Producer Producer { get; set; }
        public Guid CarId { get; internal set; }
        public decimal Price { get; set; }
    }
}
