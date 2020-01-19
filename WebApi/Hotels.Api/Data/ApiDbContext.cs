namespace Hotels.Api.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne<Hotel>()
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId); 
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
