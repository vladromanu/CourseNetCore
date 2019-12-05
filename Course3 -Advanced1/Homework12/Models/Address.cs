namespace Homework12.Models
{
    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public Geo Geo { get; set; }

        public override string ToString()
        {
            return new string($"Street: {this.Street} Suite: {this.Suite} City: {this.City} ZipCode: {this.Zipcode} Geo: {this.Geo}");
        }
    }
}