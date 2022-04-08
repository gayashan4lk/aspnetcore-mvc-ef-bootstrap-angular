using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SekiroApp.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace SekiroApp.Data
{
    public class SekiroContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public SekiroContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SekiroContextDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
              .HasData(new Order()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
                  OrderNumber = "12345"
              });
        }
    }
}
