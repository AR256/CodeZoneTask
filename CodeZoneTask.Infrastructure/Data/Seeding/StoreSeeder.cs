using CodeZoneTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Infrastructure.Data.Seeding
{
    public static class StoreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Name = "Main Warehouse",
                    Location = "123 Main St, Anytown",
                    ManagerName = "John Doe",
                    ContactNumber = "555-1234",
                    Email = "main@warehouse.com",
                    OpeningHours = "9 AM - 5 PM"
                },
                new Store
                {
                    Id = 2,
                    Name = "Downtown Store",
                    Location = "456 Market St, Big City",
                    ManagerName = "Jane Smith",
                    ContactNumber = "555-5678",
                    Email = "downtown@store.com",
                    OpeningHours = "10 AM - 8 PM"
                }
            );
        }
    }
}
