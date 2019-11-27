using Homework8.Models;
using System;
using System.Collections.Generic;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Alex intended to buy a Ford Focus 2015 model.
            Customer Alex = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                Name = "Alex"
            };

            Producer Ford = new Producer()
            {
                ProducerId = Guid.NewGuid(),
                Name = "Ford"
            };

            Car FordFocus = new Car()
            {
                CarId = Guid.NewGuid(),
                Producer = Ford,
                Name = "Focus",
                Year = 2015,
                Price = 15000M
            };

            // He walked to the FordStore in Bucuresti and agreed to buy one for *15000Euro.
            Store FordStore = new Store()
            {
                Name = "FordStore",
                City = "Bucuresti",
                Brands = new List<Producer>(),
                CarsInStock = new List<Car>(),
                Orders = new Dictionary<Guid, Order>()
            };
            FordStore.CarsInStock.Add(FordFocus);
            Alex.WalkToStore(FordStore);

            Order fordOrder = new Order()
            {
                OrderId = Guid.NewGuid(),
                Customer = Alex,
                Car = FordFocus,
                Store = FordStore
            };
            int weeksTillDelivery = FordStore.EnquiryOrder(fordOrder);
            FordStore.PlaceOrder(fordOrder);

            // They informed him it will take 4 weeks for delivery.
            Console.WriteLine($"Order <{fordOrder.OrderId}> will take <{weeksTillDelivery}> weeks to deliver");

            // He then decided to visit another store SkodaStore and agreed to buy one * for 14000Euro and 3 weeks delivery.
            Store SkodaStore = new Store()
            {
                Name = "SkodaStore",
                City = "Bucuresti",
                Brands = new List<Producer>(),
                CarsInStock = new List<Car>(),
                Orders = new Dictionary<Guid, Order>()
            };

            Producer Skoda = new Producer()
            {
                ProducerId = Guid.NewGuid(),
                Name = "Skoda"
            };

            Car SkodaFabia = new Car()
            {
                CarId = Guid.NewGuid(),
                Producer = Skoda,
                Name = "Fabia",
                Year = 2015,
                Price = 14000M
            };

            SkodaStore.CarsInStock.Add(SkodaFabia);
            Alex.WalkToStore(SkodaStore);

            Order skodaOrder = new Order()
            {
                OrderId = Guid.NewGuid(),
                Customer = Alex,
                Car = SkodaFabia,
                Store = SkodaStore
            };
            int weeksTillDeliverySkoda = FordStore.EnquiryOrder(skodaOrder);
            SkodaStore.PlaceOrder(skodaOrder);

            // They informed him it will take 4 weeks for delivery.
            Console.WriteLine($"Order <{skodaOrder.OrderId}> will take <{weeksTillDeliverySkoda}> weeks to deliver");

            // He then canceled his original order from the FordStore.
            FordStore.CancelOrder(fordOrder);

            // After 3 weeks, he received the model.
            SkodaStore.DeliverOrder(skodaOrder);
            
        }
    }
}
