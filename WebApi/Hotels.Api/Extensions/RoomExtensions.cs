using System.Security.Cryptography.Xml;
using Hotels.Api.Data.Entities;
using Hotels.Api.Resources.Hotel;
using Hotels.Api.Resources.Room;

namespace Hotels.Api.Extensions
{
    public static class RoomExtensions
    {
        public static Room MapAsEntity(this CreateRoomResource resource)
        {
            return new Room
            {
                 Number = resource.Number,
                 Name =  resource.Name,
                 Category = resource.Category
            };
        }

        public static RoomResource MapAsResource(this Room entity)
        {
            return new RoomResource
            {
                RoomId = entity.RoomId, 
                Number =  entity.Number, 
                Name = entity.Name, 
                Category = entity.Category
            };
        }
    }
}
