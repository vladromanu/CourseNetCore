namespace OpenClosedShoppingCartAfter
{
    class ItemSpecial : OrderItem
    {
        public override decimal GetItemPrice()
        {
            // $0.40 each; 3 for a $1.00
            decimal total = this.Quantity * .4m;
            int setsOfThree = this.Quantity / 3;

            return total - setsOfThree * .2m;
        }
    }
}
