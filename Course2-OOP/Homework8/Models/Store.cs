using Homework8.Models.Enums;
using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Store : IStore
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Car> CarsInStock { get; set; }
        public List<Producer> Brands { get; set; }
        public Dictionary<Guid, Order> Orders { get; set; }
        public int EnquiryOrder(Order order)
        {
            order.Status = OrderStatus.ENQUIRY;
            order.DeliveryTime = new Random().Next(1, 10);
            
            this.Orders.Add(order.OrderId, order);

            return order.DeliveryTime;
        }
        public void PlaceOrder(Order order)
        {
            if(!this.Orders.ContainsKey(order.OrderId))
            {
                throw new ArgumentOutOfRangeException("Order could not be found within the placed lists");
            }

            if(this.Orders[order.OrderId].Status != OrderStatus.ENQUIRY)
            {
                throw new ArgumentException($"Could not find an enquiry order with this order id <{order.OrderId}>");
            }

            this.Orders[order.OrderId].Status = OrderStatus.CONFIRMED;
            this.Orders[order.OrderId].ConfirmationDate = new DateTime();
        }

        public void CancelOrder(Order order)
        {
            if (!this.Orders.ContainsKey(order.OrderId))
            {
                throw new ArgumentOutOfRangeException("Order could not be found within the placed lists");
            }

            switch (this.Orders[order.OrderId].Status)
            {
                case OrderStatus.CANCELLED:
                    throw new ArgumentException($"Order already cancelled <{order.OrderId}>");
            }

            this.Orders[order.OrderId].Status = OrderStatus.CANCELLED;
            this.Orders[order.OrderId].CancellationDate = new DateTime();
        }

        public void DeliverOrder(Order order)
        {
            if (!this.Orders.ContainsKey(order.OrderId))
            {
                throw new ArgumentOutOfRangeException("Order could not be found within the placed lists");
            }

            switch (this.Orders[order.OrderId].Status)
            {
                case OrderStatus.ENQUIRY:
                    throw new ArgumentException($"Order is not confirmed yet <{order.OrderId}>");

                case OrderStatus.CANCELLED:
                    throw new ArgumentException($"Order already cancelled <{order.OrderId}>");
            }

            this.Orders[order.OrderId].Status = OrderStatus.DELIVERED;
            this.Orders[order.OrderId].DeliveryDate = new DateTime();
        }
    }
}
