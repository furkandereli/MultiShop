﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public IActionResult ConfirmDiscountCoupon(string code)
        {
            code = "BONUS20";
            var values = _discountService.GetDiscountCode(code);
            return View(values);
        }
    }
}
