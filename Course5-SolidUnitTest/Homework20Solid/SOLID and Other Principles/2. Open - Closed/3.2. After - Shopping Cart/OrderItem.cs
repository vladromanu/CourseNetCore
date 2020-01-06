namespace OpenClosedShoppingCartAfter
{
    public abstract class OrderItem : IOrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public abstract decimal GetItemPrice();
        
        public override string ToString()
        {
            return this.Sku.ToString() + " " + this.Quantity.ToString();
        }
    }
}