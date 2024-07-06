using CodeZoneTask.Core.Entities;
using CodeZoneTask.Infrastructure.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Infrastructure.Data.Context
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreItem>()
                .HasKey(si => new { si.StoreId, si.ItemId });

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Store)
                .WithMany(s => s.StoreItems)
                .HasForeignKey(si => si.StoreId);

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.StoreItems)
                .HasForeignKey(si => si.ItemId);

            StoreSeeder.Seed(modelBuilder);
            ItemSeeder.Seed(modelBuilder);
        }

    }
}
