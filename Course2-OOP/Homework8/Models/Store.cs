﻿using Homework8.Models.Basic;
using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Homework8.Models
{
    abstract class Store : IStore
    {
        public abstract string Name { get; }
        public abstract string City { get; }

        public List<Car> CarsInStock { get; set; }
        public List<Producer> Brands { get; set; }
        public Dictionary<Guid, Order> Orders { get; set; }

        public abstract int GetStoreWeeksTillDelivery();
        public abstract void SetStoreBrands();
        public abstract void SetStoreInventory();

        public Store()
        {
            this.CarsInStock = new List<Car>();
            this.Brands = new List<Producer>();
            this.Orders = new Dictionary<Guid, Order>();

            this.SetStoreBrands();
            this.SetStoreInventory();
        }

        public virtual Order RegisterOrder(Customer customer, Car car)
        {
            Order newOrder = new Order()
            {
                OrderId = Guid.NewGuid(),
                Customer = customer,
                Car = car
            };

            newOrder.ConfirmOrder();
            newOrder.DeliveryTime = this.GetStoreWeeksTillDelivery();

            this.Orders.Add(newOrder.OrderId, newOrder);

            return newOrder;
        }

        public virtual OrderStatus CancelOrder(Order order)
        {
            if (!this.Orders.ContainsKey(order.OrderId))
            {
                throw new ArgumentOutOfRangeException("Order could not be found within the placed lists");
            }

            if (this.Orders[order.OrderId].Status == OrderStatus.CANCELLED)
            {
                throw new ArgumentException($"Order already cancelled <{order.OrderId}>");
            }

            this.Orders[order.OrderId].CancelOrder();

            return this.Orders[order.OrderId].Status;
        }

        public virtual OrderStatus DeliverOrder(Order order)
        {
            if (!this.Orders.ContainsKey(order.OrderId))
            {
                throw new ArgumentOutOfRangeException("Order could not be found within the placed lists");
            }

            if (this.Orders[order.OrderId].Status == OrderStatus.CANCELLED)
            {
                throw new ArgumentException($"Order already cancelled <{order.OrderId}>");
            }

            this.Orders[order.OrderId].DeliverOrder();

            return this.Orders[order.OrderId].Status;
        }
    }
}