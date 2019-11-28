using Homework8.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Interfaces
{
    interface IOrder
    {
        public void ConfirmOrder();
        public void CancelOrder();
        public void DeliverOrder();
    }
}