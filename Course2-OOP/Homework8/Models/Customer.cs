using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Customer : IPerson
    {
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public void WalkToStore(Store store)
        {
            Console.WriteLine($"{this.Name} <{this.CustomerId}> is walking to store <{store.Name}> from city <{store.City}>");
        }
    }
}
