using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
