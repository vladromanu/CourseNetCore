using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Types
{
    [Serializable]
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
            this.Name = _name ?? throw new ArgumentNullException(nameof(_name));
            this.City = _city ?? throw new ArgumentNullException(nameof(_city));
            this.Rooms = _rooms ?? throw new ArgumentNullException(nameof(_rooms));
        }
        
        private Dictionary<Guid, Rate> GetPriceForNumberOfDays(int numberOfDays)
        {
            Dictionary<Guid, Rate> dictionary = new Dictionary<Guid, Rate>();

            for (int i = 0; i < this.Rooms.Count; i++)
            {
                dictionary.Add(this.Rooms[i].RoomTypeCode, this.Rooms[i].GetPriceForDays(numberOfDays));
            }

            return dictionary;
        }

        public Dictionary<Guid, Rate> GetRoomsUnderValue(decimal price, int numberOfDays = 1)
        {
            Dictionary<Guid, Rate> dictionary = this.GetPriceForNumberOfDays(numberOfDays);
            
            foreach (KeyValuePair<Guid, Rate> entry in dictionary)
            {
                if(entry.Value.Amount > price)
                {
                    dictionary.Remove(entry.Key);
                }
            }

            return dictionary;
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