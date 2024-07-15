using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            return Ok(await _statisticService.GetBrandCount());
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            return Ok(await _statisticService.GetCategoryCount());
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            return Ok(await _statisticService.GetProductCount());
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            return Ok(await _statisticService.GetProductAvgPrice());
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            return Ok(await _statisticService.GetMaxPriceProductName());
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            return Ok(await _statisticService.GetMinPriceProductName());
        }
    }
}
