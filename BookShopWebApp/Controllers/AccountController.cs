using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<AppUser> _userManager;
		

		public AccountController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
			
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
