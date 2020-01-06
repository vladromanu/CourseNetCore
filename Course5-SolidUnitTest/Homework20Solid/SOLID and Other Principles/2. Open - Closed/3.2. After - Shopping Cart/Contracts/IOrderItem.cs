namespace OpenClosedShoppingCartAfter
{
    interface IOrderItem
    {
        string Sku { get; set; }

        int Quantity { get; set; }

        decimal GetItemPrice();

    }
}