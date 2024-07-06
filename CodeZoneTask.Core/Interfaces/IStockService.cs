using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Interfaces
{
    public interface IStockService
    {
        Task<int> GetItemQuantityInStore(int storeId, int itemId);
        Task UpdateItemQuantityInStore(int storeId, int itemId, int quantity);
    }
}
