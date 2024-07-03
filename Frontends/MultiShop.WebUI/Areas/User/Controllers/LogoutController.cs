using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
