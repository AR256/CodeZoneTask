using CodeZoneTask.Core.Entities;
using CodeZoneTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStoreItemRepository _storeItemRepository;

        public StockService(IStoreItemRepository storeItemRepository)
        {
            _storeItemRepository = storeItemRepository;
        }

        public async Task<int> GetItemQuantityInStore(int storeId, int itemId)
        {
            var storeItem = await _storeItemRepository.GetStoreItemAsync(storeId, itemId);
            return storeItem?.Quantity ?? 0;
        }

        public async Task UpdateItemQuantityInStore(int storeId, int itemId, int quantity)
        {
            var storeItem = await _storeItemRepository.GetStoreItemAsync(storeId, itemId);
            if (storeItem != null)
            {
                storeItem.Quantity += quantity;
                await _storeItemRepository.UpdateStoreItemAsync(storeItem);
            }
            else
            {
                storeItem = new StoreItem
                {
                    StoreId = storeId,
                    ItemId = itemId,
                    Quantity = quantity
                };
                await _storeItemRepository.AddStoreItemAsync(storeItem);
            }
        }
    }
}
