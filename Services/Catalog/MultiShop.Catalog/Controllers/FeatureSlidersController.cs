﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla eklendi !");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne çıkan görsel başarıyla silindi !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla güncellendi !");
        }
    }
}
