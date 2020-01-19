using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Api.Resources.Room
{
    public class CreateRoomResource
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
