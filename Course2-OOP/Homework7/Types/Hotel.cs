using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Types
{
    class Hotel
    {
        // Props + fields
        private string name;
        private string city;
        private List<Room> rooms;

        public string City { get => city; set => city = value; }
        public string Name { get => name; set => name = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public Hotel() : this("Hotel", "City", new List<Room>())
        {

        }

        public Hotel(
            string _name,
            string _city,
            List<Room> _rooms)
        {
            Name = _name ?? throw new ArgumentNullException(nameof(_name));
            City = _city ?? throw new ArgumentNullException(nameof(_city));
            Rooms = _rooms ?? throw new ArgumentNullException(nameof(_rooms));
        }

        public decimal GetPriceForNumberOfRooms(int numberOfRooms)
        {
            return 1M;
        }

        public string Print
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"Hotel: <{this.Name}> \nCity: <{this.City}> \n");
                builder.Append("================================================\n");

                foreach (var room in this.Rooms)
                {
                    builder.Append(room.ToString() + "\n");
                }

                return builder.ToString();
            }
        }

        public override string ToString()
        {
            return this.Print;
        }
    }
}
