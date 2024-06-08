﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
