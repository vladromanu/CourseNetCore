using Homework8.Models.Basic;
using Homework8.Models.Interfaces;
using System;

namespace Homework8.Models
{
    class Order : IOrder
    {
        public Guid OrderId { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Store Store { get; set; }
        public OrderStatus Status { get; internal set; }
        public int DeliveryTime { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime CancellationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public void ConfirmOrder()
        {
            this.Status = OrderStatus.CONFIRMED;
            this.ConfirmationDate = DateTime.Now;
        }
        public void CancelOrder()
        {
            this.Status = OrderStatus.CANCELLED;
            this.CancellationDate = DateTime.Now;
        }
        public void DeliverOrder()
        {
            this.Status = OrderStatus.DELIVERED;
            this.DeliveryDate = DateTime.Now;
        }

        public Order()
        {
            Status = OrderStatus.ENQUIRY;
        }

    }
}
