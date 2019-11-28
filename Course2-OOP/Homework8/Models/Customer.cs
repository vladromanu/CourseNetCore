using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Customer : IPerson
    {
        public string name;
        public Guid customerId;

        public string Name { get => this.name; }
        public Guid CustomerId { get => this.customerId; }
        public ILogger Logger { get; set; }

        public Customer(string name)
        {
            this.name = name;
            this.customerId = Guid.NewGuid();
        }

        public void WalkToStore(Store store)
        {
            Logger.Log($"{this.Name} <{this.CustomerId}> is walking to store <{store.Name}> from city <{store.City}>");
        }

        public Car PickCar(Store store)
        {
            return store.CarsInStock[new Random().Next(0, store.CarsInStock.Count)];
        }
    }
}
