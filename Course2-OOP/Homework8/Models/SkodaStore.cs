using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class SkodaStore : Store
    {
        public override string Name { get => "Skoda Store"; }
        public override string City { get => "Bucuresti"; }

        public SkodaStore() : base()
        {
            // .. 
        }
        
        public override int GetWeeksTillDelivery()
        {
            return 3;
        }

        public override void SetStoreBrands()
        {
            this.Brands.Add(new Producer("Skoda", Guid.NewGuid()));
        }

        public override void SetStoreInventory()
        {
            Car SkodaFabia = new Car()
            {
                CarId = Guid.NewGuid(),
                Producer = this.Brands.Find(item => item.Name == "Skoda"),
                Name = "Fabia",
                Year = 2015,
                Price = new Price()
                {
                    Amount = 14000M,
                    Currency = "EUR"
                }
            };
            this.CarsInStock.Add(SkodaFabia);
        }
  
    }
}
