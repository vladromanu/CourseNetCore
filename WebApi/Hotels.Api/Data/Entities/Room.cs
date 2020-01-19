using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotels.Api.Resources;

namespace Hotels.Api.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required, MaxLength(20)]
        public string Number { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(10)]
        public string Category { get; set; }

        public string Amenities { get; set; }

        public int MaxAdultOccupancy { get; set; }

        public int MaxChildOccupancy { get; set; }

        public int HotelId { get; set; }

    }
}