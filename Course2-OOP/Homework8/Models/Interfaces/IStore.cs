using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Interfaces
{
    interface IStore
    {
        public int EnquiryOrder(Order order);
        public void PlaceOrder(Order order);
        public void CancelOrder(Order order);
    }
}
