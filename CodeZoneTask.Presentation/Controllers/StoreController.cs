using CodeZoneTask.Core.Entities;
using CodeZoneTask.Core.Interfaces;
using CodeZoneTask.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Presentation.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository storeRepository;
        public StoreController(IStoreRepository _storeRepository)
        {
            storeRepository = _storeRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var stores = await storeRepository.GetAllAsync();
                return View(stores);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var store = await storeRepository.GetByIdAsync(id);
            return View(store);
        }

        public async Task<IActionResult> AddEdit(int id = 0)
        {
            try
            {
                if (id == 0)
                    return View(new Store());
                else
                    return View(await storeRepository.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Store store)
        {
            try
            {
                if (store.Id == 0)
                    await storeRepository.AddAsync(store);
                else
                    await storeRepository.UpdateAsync(store);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await storeRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
    }
}
