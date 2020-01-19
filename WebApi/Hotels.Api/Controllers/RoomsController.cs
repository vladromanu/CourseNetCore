using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hotels.Api.Data;
using Hotels.Api.Data.Entities;
using Hotels.Api.Extensions;
using Hotels.Api.Resources.Hotel;
using Hotels.Api.Resources.Room;
using Hotels.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Api.Controllers
{
    [Route("api/hotels/{hotelId}/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly INotificationService _notificationService;

        public RoomsController(ApiDbContext context, INotificationService notificationService)
        {
            this._context = context;
            this._notificationService = notificationService;
        }

        // GET: api/hotels/{hotelId}/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int hotelId, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms was called");

            var hotel = await this._context.Hotels.FindAsync(new object[] { hotelId }, token);
            if (hotel == null)
            {
                return this.NotFound();
            }

            if (hotel.Rooms == null)
            {
                return this.NoContent();
            }

            return hotel.Rooms.ToList();
        }


        // GET: api/hotels/{hotelId}/rooms/{roomId}
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<RoomResource>> GetRoomById(int hotelId, int id, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms/{id} was called");

            var hotel = await this._context.Hotels.FindAsync(new object[] { hotelId }, token);
            if (hotel == null)
            {
                return this.NotFound();
            }

            var room = hotel.Rooms.Find(e => e.Id == id);
            if (room == null)
            {
                return this.NotFound();
            }

            return Ok(room.MapAsResource());
        }

        // POST: api/hotels/{hotelId}/rooms
        [HttpPost]
        public async Task<ActionResult<RoomResource>> Post(int hotelId, [FromBody] CreateRoomResource model, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms POST was called");

            var hotel = await this._context.Hotels.FindAsync(new object[] { hotelId }, token);
            if (hotel == null)
            {
                return this.NotFound();
            }

            var entity = model.MapAsEntity();

            hotel.Rooms.Add(entity);
            this._context.Entry(hotel).State = EntityState.Modified;

            if (token.IsCancellationRequested)
            {
                return this.NoContent();
            }

            await this._context.SaveChangesAsync(token);

            this._notificationService.Notify($"api/hotels/{hotelId}/rooms POST => room with id {entity.Id} created!");

            return this.CreatedAtAction("GetRoomById", new
            {
                hotelId = hotel.Id,
                id = entity.Id,
                token
            }, entity.MapAsResource());
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<HotelResource>> DeleteHotel(int id, CancellationToken token)
        {
            var hotel = await this._context.Hotels.FindAsync(new object[] { id }, token);

            if (hotel == null)
            {
                return this.NotFound();
            }

            var room = hotel.Rooms.Find(e => e.Id == id);
            if (room == null)
            {
                return this.NotFound();
            }

            hotel.Rooms.Remove(room);
            this._context.Entry(hotel).State = EntityState.Modified;

            await this._context.SaveChangesAsync(token);

            return hotel.MapAsResource();
        }
    }
}
