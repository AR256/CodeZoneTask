using CodeZoneTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Infrastructure.Data.Seeding
{
    public static class ItemSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "15-inch, 16GB RAM, 512GB SSD",
                    Category = "Electronics",
                    Price = 999.99m,
                    SKU = "LAP123",
                    Manufacturer = "TechCorp",
                    ExpirationDate = null
                },
                new Item
                {
                    Id = 2,
                    Name = "Milk",
                    Description = "1 liter, full cream",
                    Category = "Groceries",
                    Price = 1.99m,
                    SKU = "MIL456",
                    Manufacturer = "DairyBest",
                    ExpirationDate = DateTime.Now.AddMonths(1)
                }
            );
        }
    }
}
