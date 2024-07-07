using AutoMapper;
using BookShopWebApp.Areas.Admin.Models;
//using BookShopWebApp.Models;

//using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		//private readonly IMapper _mapper;

		private readonly ShoppingCartManager _shoppingCartManager;

		public UserController(UserManager<AppUser> userManager, ShoppingCartManager shoppingCartManager)
		{
			_userManager = userManager;
			_shoppingCartManager = shoppingCartManager;
		}

		public IActionResult Index()
		{
			List<AppUser> users = _userManager.Users.ToList();


			return View(users);
		}



		public async Task<IActionResult> Edit(int id)
		{


			var user = await _userManager.FindByIdAsync(id.ToString());


			var model = new UserViewModel
			{
				UserId = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Email = user.Email,
				Address = user.Adress,
				Gender = user.Gender

			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UserViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _userManager.FindByIdAsync(model.UserId.ToString());



			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Email;
			user.Adress = model.Address;
			user.Gender = model.Gender;

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(Index));
			}
			else
				return View(model);

		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id == 1)
			{
				TempData["Message"] = "Admin Kullanıcısı Silinemez!";
				return RedirectToAction(nameof(Index));
			}


			var user = await _userManager.FindByIdAsync(id.ToString());



			return View(user);
		}

		[HttpPost, ActionName("DeleteConfirmed")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());

			var shoppingCart = _shoppingCartManager.GetAll().FirstOrDefault(s => s.AppUserId == user.Id);

			if (shoppingCart is not null)
			{
				_shoppingCartManager.Delete(shoppingCart);
			}

			await _userManager.RemoveFromRoleAsync(user, "Customer");

			var result = await _userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
				return RedirectToAction(nameof(Index));
			}
			else
				return View(user);

		}




	}
}
