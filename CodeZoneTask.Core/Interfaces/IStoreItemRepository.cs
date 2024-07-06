using CodeZoneTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Interfaces
{
    public interface IStoreItemRepository
    {
        Task<StoreItem> GetStoreItemAsync(int storeId, int itemId);
        Task UpdateStoreItemAsync(StoreItem storeItem);
        Task AddStoreItemAsync(StoreItem storeItem);
    }
}
