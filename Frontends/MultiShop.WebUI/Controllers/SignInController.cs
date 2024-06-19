using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
