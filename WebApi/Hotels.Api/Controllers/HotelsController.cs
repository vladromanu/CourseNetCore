using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hotels.Api.Data.Entities;
using Hotels.Api.Extensions;
using Hotels.Api.Resources.Hotel;
using Hotels.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;

namespace Hotels.Api.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly INotificationService _notificationService;
        private readonly IMemoryCache _memoryCache;

        public HotelsController(ApiDbContext context, INotificationService notificationService)
        {
            this._context = context;
            this._notificationService = notificationService;
            this._memoryCache = MemoryCache.
        }


        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels(CancellationToken token)
        {
            this._notificationService.Notify("api/hotels was called");
            return await this._context.Hotels.ToListAsync(token);
        }


        // GET: api/hotels/5
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<HotelResource>> GetHotelById(int id, CancellationToken token)
        {
            var key = $"_entry_{id}";
            if (this.memoryCache.TryGetValue(key, out HotelResource hotelResource))
            {
                this._notificationService.Notify($"api/hotels/{id} was called. Cached hit !");
            }
            else
            {
                var hotel = await this._context.Hotels.FindAsync(new object[] { id }, token);
                if (hotel == null)
                {
                    return this.NotFound();
                }

                hotelResource = hotel.MapAsResource();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                this.memoryCache.Set(key, hotelResource, cacheEntryOptions);
            }
            
            return Ok(hotelResource);
        }


        // POST: api/hotels
        [HttpPost]
        public async Task<ActionResult<HotelResource>> Post([FromBody] CreateHotelResource model, CancellationToken token)
        {
            var entity = model.MapAsEntity();

            this._context.Hotels.Add(entity);
            if (token.IsCancellationRequested)
            {
                return this.NoContent();
            }

            await this._context.SaveChangesAsync(token);

            this._notificationService.Notify($"api/hotels POST => hotel with id {entity.Id} created!");

            return this.CreatedAtAction("GetHotelById", new
            {
                id = entity.Id, token
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

            this._context.Hotels.Remove(hotel);
            await this._context.SaveChangesAsync(token);

            return hotel.MapAsResource();
        }


        // PUT: api/hotels/5
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<HotelResource>> PutHotel(int id, [FromBody] UpdateHotelResource model, CancellationToken token)
        {
            this._notificationService.Notify($"api/hotels/{id} PUT was called");

            var hotel = await this._context.Hotels.FindAsync(new object[] { id }, token);
            if (hotel == null)
            {
                return this.NotFound();
            }

            hotel.City = model.City;
            this._context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync(token);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.HotelExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return hotel.MapAsResource();
        }

        private bool HotelExists(int id)
        {
            return this._context.Hotels.Any(e => e.Id == id);
        }
    }
}
