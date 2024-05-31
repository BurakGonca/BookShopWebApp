using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
