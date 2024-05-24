using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Areas.Admin.Views
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
