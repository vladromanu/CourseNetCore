using Homework8.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class FordStore : Store
    {
        public override string Name { get => "Ford Store"; }
        public override string City { get => "Bucuresti"; }

        public FordStore() : base()
        {
            // ..
        }
        
        public override int GetStoreWeeksTillDelivery()
        {
            return 4;
        }

        public override void SetStoreBrands()
        {
            this.Brands.Add(new Producer("Ford", Guid.NewGuid()));
        }

        public override void SetStoreInventory()
        {
            Car FordFocus = new Car()
            {
                CarId = Guid.NewGuid(),
                Producer = this.Brands.Find(item => item.Name == "Ford"),
                Name = "Focus",
                Year = 2015,
                Price = new Price()
                {
                    Amount = 15000M,
                    Currency = "EUR"
                }
            };
            this.CarsInStock.Add(FordFocus);
        }
    }
}
