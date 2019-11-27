using Homework8.Models.Enums;
using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
