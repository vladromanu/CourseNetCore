namespace Homework8.Models.Basic
{
    struct Price
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return new string($"Price: {this.Amount} {this.Currency}");
        }
    }
}
