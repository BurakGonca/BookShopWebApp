using BookShopWebApp.Models;
using BookShopWebApp.Models.Account;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookShopWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IConfiguration _configuration;

        private readonly ShoppingCartManager _shoppingCartManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICompositeViewEngine viewEngine, IConfiguration configuration, RoleManager<IdentityRole<int>> roleManager, ShoppingCartManager shoppingCartManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _viewEngine = viewEngine;
            _configuration = configuration;
            _roleManager = roleManager;
            _shoppingCartManager = shoppingCartManager;
        }

        public IActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            ModelState.Remove("UserId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var users = _userManager.Users.ToList();

            foreach (var item in users)
            {
                if (model.Email == item.Email)
                {
                    ViewBag.ErrorMessage = $"{model.Email} adresi zaten kayıtlıdır";
                    return View(model);
                }
            }

            var hasher = new PasswordHasher<AppUser>();

            AppUser user = new AppUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                EmailConfirmed = true,
                NormalizedEmail = model.Email.ToUpper(),
                PasswordHash = hasher.HashPassword(null, model.Password),
                Adress = model.Adress,
                Gender = model.Gender,
                UserType = BS.Enums.UserType.Customer,
                UserName = model.Name,
                NormalizedUserName = model.Name.ToUpper()
            };

            IdentityResult result = await _userManager.CreateAsync(user);

            //her kullanıcı olusturulurken kendisine ait bir alisveris sepeti olusturdum
            ShoppingCartDto dto = new ShoppingCartDto();
            dto.AppUserId = user.Id;
            _shoppingCartManager.Create(dto);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");


                TempData["Message"] = "Kayıt başarılı! Giriş yapabilirsiniz.";

                return RedirectToAction(nameof(Login));
            }
            else
            {
                ViewBag.ErrorMessage = "Kayıt başarısız, lütfen tüm alanları eksiksiz ve doğru bir şekilde doldurunuz";
                return View(model);
            }


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
                ViewBag.ErrorMessage = "Kullanıcı adı  yanlıştır.";
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            if (!signInResult.Succeeded)
            {
                ViewBag.ErrorMessage = "Şifre yanlıştır.";
                return View(model);
            }

            ViewBag.LoginSuccess = user.Name;
            return RedirectToAction("Index", "Home");
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }





    }
}

