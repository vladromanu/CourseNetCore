namespace OpenClosedShoppingCartAfter
{
    class ItemByCount : OrderItem
    {
        public override decimal GetItemPrice()
        {
            return this.Quantity * 5m;
        }
    }
}
