using System.Collections.Generic;

namespace Hotels.Api.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Hotel
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string City { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
