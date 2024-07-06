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
    public class StoreItemRepository: IStoreItemRepository
    {
        private readonly StoreContext _context;

        public StoreItemRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<StoreItem> GetStoreItemAsync(int storeId, int itemId)
        {
            return await _context.StoreItems
                .FirstOrDefaultAsync(si => si.StoreId == storeId && si.ItemId == itemId);
        }

        public async Task UpdateStoreItemAsync(StoreItem storeItem)
        {
            _context.StoreItems.Update(storeItem);
            await _context.SaveChangesAsync();
        }

        public async Task AddStoreItemAsync(StoreItem storeItem)
        {
            _context.StoreItems.Add(storeItem);
            await _context.SaveChangesAsync();
        }
    }
}
