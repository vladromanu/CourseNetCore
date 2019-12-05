namespace Homework12.Models
{
    public class Geo
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        public override string ToString()
        {
            return new string($"Lat: {this.Lat} Lng: {this.Lng}");
        }
    }
}