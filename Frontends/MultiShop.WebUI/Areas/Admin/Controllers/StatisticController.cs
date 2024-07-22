using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _catalogStatisticService.GetBrandCount();
            ViewBag.BrandCount = value;
            return View();
        }
    }
}
