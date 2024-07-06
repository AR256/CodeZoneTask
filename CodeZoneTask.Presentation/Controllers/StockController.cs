using CodeZoneTask.Core.Interfaces;
using CodeZoneTask.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeZoneTask.Presentation.Controllers
{
    public class StockController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStockService _stockService;

        public StockController(IStoreRepository storeRepository, IItemRepository itemRepository, IStockService stockService)
        {
            _storeRepository = storeRepository;
            _itemRepository = itemRepository;
            _stockService = stockService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Stores = new SelectList(await _storeRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Items = new SelectList(await _itemRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentQuantity(int storeId, int itemId)
        {
            var quantity = await _stockService.GetItemQuantityInStore(storeId, itemId);
            return Json(quantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(StockViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _stockService.UpdateItemQuantityInStore(model.StoreId, model.ItemId, model.Quantity);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Stores = new SelectList(await _storeRepository.GetAllAsync(), "Id", "Name", model.StoreId);
            ViewBag.Items = new SelectList(await _itemRepository.GetAllAsync(), "Id", "Name", model.ItemId);
            return View("Index", model);
        }
    }
}
