using AutoMapper;
using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShopWebApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly OrderManager _orderManager;
       
       
        private IMapper _mapper;

		public OrderController(OrderManager orderManager)
		{
			_orderManager = orderManager;
			

			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{

				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.Payment, y => y.MapFrom(z => z.Payment));
				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<OrderViewModel, OrderDto>().ReverseMap();


				configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
				configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.Orders, y => y.MapFrom(z => z.Orders));
				configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
				configuration.CreateMap<UserViewModel, AppUserDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<UserViewModel, AppUserDto>().ReverseMap();

				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ForMember(x => x.Book, y => y.MapFrom(z => z.Book));
				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ReverseMap();

				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();

				configuration.CreateMap<PaymentViewModel, PaymentDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<PaymentViewModel, PaymentDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				configuration.CreateMap<PaymentViewModel, PaymentDto>().ReverseMap();




			});
			_mapper = configuration.CreateMapper();
			
		}

		public IActionResult Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			
			List<OrderDto> dtos = _orderManager.GetAll().Where(o => o.AppUserId == Convert.ToInt32(userId)).ToList();

           
			List<OrderViewModel> models = _mapper.Map<List<OrderViewModel>>(dtos);

            
            return View(models);
        }

        public IActionResult Delete(int id)
        {
            var orderDto = _orderManager.GetById(id);

            if (orderDto is not null)
                _orderManager.Delete(orderDto);

            TempData["Message"] = "Siparişiniz başarıyla iptal edilmiştir.";


            return RedirectToAction("Index");

        }
    }
}
