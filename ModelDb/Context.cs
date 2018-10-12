using System;
using Microsoft.EntityFrameworkCore;
using ModelDb.Models;

namespace ModelDb
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<RepairType> RepairType { get; set; }
        public DbSet<SpecialOffer> SpecialOffer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=carservice.db");
        }

        public Context() : base ()
        {
            Database.EnsureCreated();
        }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

    }
}
