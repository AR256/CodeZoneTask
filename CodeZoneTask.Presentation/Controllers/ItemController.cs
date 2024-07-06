using CodeZoneTask.Core.Entities;
using CodeZoneTask.Core.Interfaces;
using CodeZoneTask.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeZoneTask.Presentation.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository itemRepository;
        private readonly IStoreRepository storeRepository;
        public ItemController(IItemRepository _itemRepository, IStoreRepository _storeRepository)
        {
            itemRepository = _itemRepository;
            storeRepository = _storeRepository;
        }
        // GET: ItemController
        public async Task<ActionResult> Index()
        {
            try
            {
                var items = await itemRepository.GetAllAsync();
                return View(items);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> AddEdit(int? id)
        {
            if (id == null)
            {
                return View(new Item());
            }

            var item = await itemRepository.GetByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    await itemRepository.AddAsync(item);
                }
                else
                {
                    await itemRepository.UpdateAsync(item);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Index);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await itemRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
    }
}
