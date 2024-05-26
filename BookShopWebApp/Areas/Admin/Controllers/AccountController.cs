using BS.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookShopWebApp.Areas.Admin.Models.Account;
using BookShopWebApp.Services;
using BookShopWebApp.Models.Account;
using FluentValidation;

namespace BookShopWebApp.Areas.Admin.Controllers
{

	[Area("Admin")]
	public class AccountController : Controller
	{

        private IValidator<LoginViewModel> _validator;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IMailService _mailService;

        public AccountController(IValidator<LoginViewModel> validator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMailService mailService)
        {
            _validator = validator;
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();
            return View(model);
		}

		[HttpPost]
		public IActionResult Login(string email, string password)
		{
			if (email == "admin@admin.com" && password == "123456")
			{
				return RedirectToAction("Index", "Home", new { area = "Admin" });

			}
			ViewBag.FailLogin = "Girmiş olduğunuz bilgiler yanlıştır";

			return View();


		}

		public IActionResult Logout()
		{
			return RedirectToAction(nameof(Login));
		}


		public IActionResult Register()
		{
			RegisterViewModel registerViewModel = new RegisterViewModel();

			return View(registerViewModel);
		}

		[HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
			if (!ModelState.IsValid)
			{
                return View(registerViewModel);
            }

			return RedirectToAction(nameof(Login));

            
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }



    }





}
