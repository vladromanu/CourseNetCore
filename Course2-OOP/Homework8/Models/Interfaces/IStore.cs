using Homework8.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Interfaces
{
    interface IStore
    {
        public List<Car> CarsInStock { get; set; }
        public List<Producer> Brands { get; set; }
        public Dictionary<Guid, Order> Orders { get; set; }

        public Order RegisterOrder(Customer customer, Car car);
        public OrderStatus CancelOrder(Order order);
        public OrderStatus DeliverOrder(Order order);

    }
}