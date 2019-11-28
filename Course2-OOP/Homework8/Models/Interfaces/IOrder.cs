namespace Homework8.Models.Interfaces
{
    interface IOrder
    {
        public void ConfirmOrder();
        public void CancelOrder();
        public void DeliverOrder();
    }
}