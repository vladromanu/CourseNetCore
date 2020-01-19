using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Api.Resources.Room
{
    public class UpdateRoomResource
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public List<string> Amenities { get; set; }

        public int MaxAdultOccupancy { get; set; }

        public int MaxChildOccupancy { get; set; }
    }
}
