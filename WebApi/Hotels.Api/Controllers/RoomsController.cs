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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Hotels.Api.Controllers
{
    [Route("api/hotels/{hotelId}/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly INotificationService _notificationService;
        private IConfiguration _config;
        private IMemoryCache _cache;

        private double _cacheTimeout;
        
        public RoomsController(ApiDbContext context, INotificationService notificationService, IConfiguration iConfig, IMemoryCache memoryCache)
        {
            this._context = context;
            this._notificationService = notificationService;
            
            // Usage of the in-memory cache
            this._cache = memoryCache;

            // Usage of the configuration options
            this._config = iConfig;
            this._cacheTimeout = double.Parse(this._config
                                    .GetSection("AppSettings")
                                    .GetSection("RoomSettings")
                                    .GetSection("CacheTimeout").Value, System.Globalization.CultureInfo.InvariantCulture);
        }

        // GET: api/hotels/{hotelId}/rooms
        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms(int hotelId, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms was called");

            var key = $"C_HOTEL_ROOMS_{hotelId}";
            if (this._cache.TryGetValue(key, out List<Room> roomList))
            {
                this._notificationService.Notify($"api/hotels/{hotelId}/rooms cached hit !");
            }
            else
            {
                this._notificationService.Notify($"api/hotels/{hotelId}/rooms <Cache> not hit !");

                var hotel = await this._context.Hotels
                    .Include(h => h.Rooms)
                    .FirstOrDefaultAsync(h => h.Id == hotelId, token);

                
                if (hotel == null) return this.NotFound();
                if (hotel.Rooms == null) return this.NoContent();


                roomList = hotel.Rooms;
                
                // Update cache 
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(this._cacheTimeout));

                this._cache.Set(key, roomList, cacheEntryOptions);
            }

            return roomList;
        }


        // GET: api/hotels/{hotelId}/rooms/{roomId}
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<RoomResource>> GetRoomById(int hotelId, int id, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms/{id} was called");

            var key = $"C_ROOM_{hotelId}_{id}";
            if (this._cache.TryGetValue(key, out RoomResource roomResource))
            {
                this._notificationService.Notify($"api/hotels/{hotelId}/rooms cached hit !");
            }
            else
            {
                var hotel = await this._context.Hotels
                    .Include(i => i.Rooms)
                    .FirstOrDefaultAsync(i => i.Id == hotelId, token);

                if (hotel == null)  return this.NotFound();
                
                var room = hotel.Rooms.ToList()
                    .Where(e => e.RoomId == id)
                    .FirstOrDefault();
                
                if (room == null)   return this.NotFound();

                roomResource = room.MapAsResource();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(this._cacheTimeout));

                this._cache.Set(key, roomResource, cacheEntryOptions);

            }

            return Ok(roomResource);
        }

        // POST: api/hotels/{hotelId}/rooms
        [HttpPost]
        public async Task<ActionResult<RoomResource>> Post(int hotelId, [FromBody] CreateRoomResource model, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{hotelId}/rooms POST was called");

            var hotel = this._context.Hotels
                    .Include(h => h.Rooms)
                    .Where(h => h.Id == hotelId)
                    .FirstOrDefault();
            
            if (hotel == null) return this.NotFound();

            var room = model.MapAsEntity();
            room.HotelId = hotelId;

            // STOP on cancellation issued
            if (token.IsCancellationRequested) return this.NoContent();

            this._context.Rooms.Add(room);
            this._context.Entry(hotel).State = EntityState.Modified;
            await this._context.SaveChangesAsync(token);

            // STOP on cancellation issued
            if (token.IsCancellationRequested) return this.NoContent();

            this._notificationService.Notify($"api/hotels/{hotelId}/rooms POST => room with id {room.RoomId} created!");

            return this.CreatedAtAction("GetRoomById", new
            {
                hotelId = hotel.Id,
                id = room.RoomId,
                token
            }, room.MapAsResource());
        }

        // DELETE: api/hotels/{hotelId}/rooms
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<HotelResource>> DeleteRoom(int hotelId, int id, CancellationToken token)
        {
            var room = await this._context.Rooms
                   .FirstOrDefaultAsync(h => h.HotelId == hotelId && h.RoomId == id, token);

            if (room == null) return this.NotFound();

            this._context.Rooms.Remove(room);
            await this._context.SaveChangesAsync(token);

            // Invalidate cache
            this._cache.Remove($"C_ROOM_{hotelId}_{id}");
            this._cache.Remove($"C_HOTEL_ROOMS_{hotelId}");

            return Ok();
        }
    }
}
