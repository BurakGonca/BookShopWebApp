using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Contact()
		{
			return View();
		}
	}
}
