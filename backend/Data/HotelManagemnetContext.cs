using Hotel_Management.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Data
{
    public class HotelManagemnetContext : DbContext
    {
        public HotelManagemnetContext(DbContextOptions<HotelManagemnetContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}
