using Hotel_Management.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Data
{
    public class HotelManagementContext : DbContext
    {
        public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>().HasOne(x => x.Hotel).WithMany(p => p.Room).HasForeignKey(x => x.Hotel_id);
            builder.Entity<Employee>().HasOne(x => x.Hotel).WithMany(p => p.Employee).HasForeignKey(x => x.Hotel_id);
            builder.Entity<Employee>().Property(x => x.DeletionAt).HasDefaultValue(null);
            builder.Entity<Client>().Property(x => x.DeletionAt).HasDefaultValue(null);
            builder.Entity<Reservation>().HasOne(x => x.Client).WithMany(p => p.Reservation).HasForeignKey(x => x.Client_id).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Reservation>().HasOne(x => x.Room).WithMany(p => p.Reservation).HasForeignKey(x => x.Room_id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Payment>().HasOne(x => x.Reservation).WithOne(p => p.Payment).HasForeignKey<Payment>(x => x.Reservation_id);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}
