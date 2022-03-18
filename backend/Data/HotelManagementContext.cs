﻿using Hotel_Management.Model.Entity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>().HasOne(x => x.Hotel).WithMany(p => p.Room).HasForeignKey(x => x.Hotel_id);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}
