using AutoMapper;
using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShopWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShoppingCartManager _shoppingCartManager;

        private IMapper _mapper;

        public ShoppingCartController(ShoppingCartManager shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;

            MapperConfiguration configuration = new MapperConfiguration(configuration =>
            {

                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));

                configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();



                configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));




            });
            _mapper = configuration.CreateMapper();
        }


		//public IActionResult Index()
		//{
		//	List<ShoppingCartDto> shoppingCartDto = _shoppingCartManager.GetAll().ToList();

		//	List<ShoppingCartViewModel> models = new List<ShoppingCartViewModel>();

		//	foreach (ShoppingCartDto dto in shoppingCartDto)
		//	{
		//		ShoppingCartViewModel shoppingCartView = new ShoppingCartViewModel();
		//		shoppingCartView = _mapper.Map<ShoppingCartViewModel>(dto);
		//		models.Add(shoppingCartView);

		//	}



		//	return View(models);
		//}


		public IActionResult Index()
		{
			
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return Unauthorized(); 
			}

			
			List<ShoppingCartDto> shoppingCartDto = _shoppingCartManager
				.GetAll()
				.Where(cart => cart.AppUserId.ToString() == userId)
				.ToList();

			List<ShoppingCartViewModel> models = new List<ShoppingCartViewModel>();

			foreach (var dto in shoppingCartDto)
			{
				var shoppingCartView = _mapper.Map<ShoppingCartViewModel>(dto);
				models.Add(shoppingCartView);
			}

			return View(models);
		}








	}
}
