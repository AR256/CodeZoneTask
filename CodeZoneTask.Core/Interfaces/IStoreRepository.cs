using CodeZoneTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store> GetByIdAsync(int id);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(int id);
    }
}
