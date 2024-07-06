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
    public class StoreRepository: IStoreRepository
    {
        private readonly StoreContext context;
        public StoreRepository(StoreContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(Store store)
        {
            context.Stores.Add(store);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var store = await context.Stores.FindAsync(id);
            context.Stores.Remove(store);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await context.Stores.ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await context.Stores.FindAsync(id);
        }

        public async Task UpdateAsync(Store store)
        {
            context.Stores.Update(store);
            await context.SaveChangesAsync();
        }
    }
}
