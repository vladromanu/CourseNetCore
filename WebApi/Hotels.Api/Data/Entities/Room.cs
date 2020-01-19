using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotels.Api.Resources;

namespace Hotels.Api.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public string Amenities { get; set; }

        public int MaxAdultOccupancy { get; set; }

        public int MaxChildOccupancy { get; set; }
    }
}