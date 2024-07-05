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

                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();

                configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
				configuration.CreateMap<UserViewModel, AppUserDto>().ReverseMap();

                configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.Payment, y => y.MapFrom(z => z.Payment));
                configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
                configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
                configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<OrderViewModel, OrderDto>().ReverseMap();

                configuration.CreateMap<ShoppingCartBookViewModel, ShoppingCartBookDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
                configuration.CreateMap<ShoppingCartBookViewModel, ShoppingCartBookDto>().ForMember(x => x.Book, y => y.MapFrom(z => z.Book));
				configuration.CreateMap<ShoppingCartBookViewModel, ShoppingCartBookDto>().ReverseMap();



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

			List<ShoppingCartViewModel> models = _mapper.Map<List<ShoppingCartViewModel>>(shoppingCartDto);

			foreach (var dto in shoppingCartDto)
			{
				var shoppingCartView = _mapper.Map<ShoppingCartViewModel>(dto);
				models.Add(shoppingCartView);
			}

			return View(models);
		}

        //var booksDto = _bookManager.GetAll().ToList();
        //var booksViewModel = _mapper.Map<List<BookViewModel>>(booksDto);






    }
}
