using CodeZoneTask.Core.Entities;
using CodeZoneTask.Core.Interfaces;
using CodeZoneTask.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Infrastructure.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreContext context;
        public ItemRepository(StoreContext _context)
        {
            context = _context;
        }
        public async Task AddAsync(Item item)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await context.Items.FindAsync(id);
            context.Items.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
