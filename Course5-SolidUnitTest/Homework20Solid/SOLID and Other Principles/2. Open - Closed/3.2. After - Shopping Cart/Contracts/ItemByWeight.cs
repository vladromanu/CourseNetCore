namespace OpenClosedShoppingCartAfter
{
    class ItemByWeight : OrderItem
    {
        public override decimal GetItemPrice()
        {
            return this.Quantity * 4m / 1000;
        }
    }
}
