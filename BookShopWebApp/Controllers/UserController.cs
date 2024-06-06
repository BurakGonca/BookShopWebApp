using BookShopWebApp.Models;
using BookShopWebApp.Models.Account;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Text;

namespace BookShopWebApp.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ICompositeViewEngine _viewEngine;
		private readonly IConfiguration _configuration;

		private readonly string _username;
		private readonly string _password;

		public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICompositeViewEngine viewEngine, IConfiguration configuration, RoleManager<IdentityRole<int>> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_viewEngine = viewEngine;
			_configuration = configuration;
			_roleManager = roleManager;

			
		}

		public IActionResult Register()
		{
			UserViewModel model = new UserViewModel();
			return View(model);
		}

		[HttpPost]
		public IActionResult Register(UserViewModel model)
		{
			ModelState.Remove("UserId");

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var users = _userManager.Users.ToList();

			// User Kayıt işlemleri yapılacaktır.
			AppUser user = new AppUser
			{
				Name = model.Name,
				Surname = model.Surname,
				Email = model.Email,
				PasswordHash = model.Password,
				Adress = model.Adress,
				Gender = model.Gender
			};

			IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();
			return View(model);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			AppUser user = _userManager.FindByEmailAsync(model.Email).Result;

			if (user == null)
			{
				ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlıştır.";
				return View(model);
			}

			Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

			if (!signInResult.Succeeded)
			{
				bool emailConfirm = _userManager.IsEmailConfirmedAsync(user).Result;

				if (!emailConfirm)
				{
					ViewBag.ErrorMessage = "Mail doğrulanmamıştır.";
					return View(model);
				}

				ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlıştır.";
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}

