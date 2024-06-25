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
using FluentValidation.Results;
using FluentValidation.AspNetCore;

namespace BookShopWebApp.Areas.Admin.Controllers
{

	[Area("Admin")]
	public class AccountController : Controller
	{

        private IValidator<LoginViewModel> _validator;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        

        public AccountController(IValidator<LoginViewModel> validator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _validator = validator;
            _userManager = userManager;
            _signInManager = signInManager;
            
        }

        public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();
            return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                ModelState.Clear();
                validationResult.AddToModelState(ModelState);
                return View(model);
            }

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("UserNotFound", "Kullanıcı adı veya şifre yanlış");
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            if (result.IsLockedOut)
            {
                //return RedirectToAction("LockOut", "Account", new { area = "Admin" });
                ModelState.AddModelError("UserNotFound", "Hesabınız kitlenmiştir.");
                return View(model);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa", "Account", new { area = "Admin" });
            }

            if (result.IsNotAllowed)
            {
                //return RedirectToAction("IsNotAllowed", "Account", new { area = "Admin" });
                string? link = Url.ActionLink("SendValidateMail", "Account", new { area = "Admin" });

                ModelState.AddModelError("UserNotFound", $"Hesabınız henüz doğrulanmamış lütfen mail adresinizi doğrulayın.<a href=\"{link}\">Tekrar Gönder</a>");
                return View(model);
            }

            ModelState.AddModelError("UserNotFound", "Kullanıcı adı veya şifre yanlış");
            return View(model);
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
