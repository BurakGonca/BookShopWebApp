using AutoMapper;
using BookShopWebApp.Areas.Admin.Models;
using BookShopWebApp.Areas.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
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
				
				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.ShoppingCart, y => y.MapFrom(z => z.ShoppingCart));
				configuration.CreateMap<OrderViewModel, OrderDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<OrderViewModel, OrderDto>().ReverseMap();



				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				
				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ForMember(x => x.Book, y => y.MapFrom(z => z.Book));
				configuration.CreateMap<OrderDetailViewModel, OrderDetailDto>().ReverseMap();

				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();

				
				configuration.CreateMap<PaymentViewModel, PaymentDto>().ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
				configuration.CreateMap<PaymentViewModel, PaymentDto>().ReverseMap();




			});
			_mapper = configuration.CreateMapper();

		}

		public IActionResult Index()
		{



			List<OrderDto> dtos = _orderManager.GetAll().ToList();


			List<OrderViewModel> models = _mapper.Map<List<OrderViewModel>>(dtos);


			return View(models);
		}

		public IActionResult Delete(int id)
		{
			var orderDto = _orderManager.GetById(id);

			if (orderDto is not null)
				_orderManager.Delete(orderDto);

			TempData["Message"] = "Sipariş başarıyla iptal edilmiştir.";


			return RedirectToAction("Index");

		}
	}
}
