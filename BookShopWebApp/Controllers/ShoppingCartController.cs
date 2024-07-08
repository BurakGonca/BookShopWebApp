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
	public class ShoppingCartController : Controller
	{
		private BookManager _bookManager;
		private ShoppingCartManager _shoppingCartManager;
		private ShoppingCartBookManager _shoppingCartBookManager;

		private OrderManager _orderManager;

		private IMapper _mapper;

		public ShoppingCartController(ShoppingCartManager shoppingCartManager, ShoppingCartBookManager shoppingCartBookManager, BookManager bookManager, OrderManager orderManager)
		{
			_bookManager = bookManager;
			_shoppingCartManager = shoppingCartManager;
			_shoppingCartBookManager = shoppingCartBookManager;
			_orderManager = orderManager;

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



				//eksikler


				configuration.CreateMap<BookDto, BookViewModel>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
				configuration.CreateMap<BookDto, BookViewModel>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookDto, BookViewModel>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
				configuration.CreateMap<BookDto, BookViewModel>().ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
				configuration.CreateMap<BookDto, BookViewModel>().ReverseMap();



				configuration.CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();

			});
			_mapper = configuration.CreateMapper();

		}


		public IActionResult Index()
		{

			var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var shoppingCartId = _shoppingCartManager.GetAll().FirstOrDefault(s => s.AppUserId == userId).Id;

			List<ShoppingCartBookDto> dtos = _shoppingCartBookManager.GetAll().Where(s => s.ShoppingCartId == shoppingCartId).ToList();


			foreach (var item in dtos)
			{
				item.Book = _bookManager.GetById(item.BookId);

				//item.ShoppingCart = _shoppingCartManager.GetById(item.ShoppingCartId);
			}


			List<ShoppingCartBookViewModel> models = _mapper.Map<List<ShoppingCartBookViewModel>>(dtos);


			return View(models);
		}


		public IActionResult Delete(int id)
		{
			var shoppingCartBook = _shoppingCartBookManager.GetById(id);

			if (shoppingCartBook is not null)
				_shoppingCartBookManager.Delete(shoppingCartBook);


			return RedirectToAction("Index");
		}

		public IActionResult ClearCart()
		{
			var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var shoppingCartId = _shoppingCartManager.GetAll().FirstOrDefault(s => s.AppUserId == userId).Id;

			var shoppingCartBooks = _shoppingCartBookManager.GetAll()
				.Where(s => s.ShoppingCartId == shoppingCartId).ToList();

			if (shoppingCartBooks is not null)
			{
				foreach (var item in shoppingCartBooks)
				{
					_shoppingCartBookManager.Delete(item);
				}
			}


			return RedirectToAction("Index");
		}


		public IActionResult AddToOrder()
		{
			

			var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var shoppingCart = _shoppingCartManager.GetAll().FirstOrDefault(s => s.AppUserId == userId);

			
			var shoppingCartId = shoppingCart.Id;

			var shoppingCartBooks = _shoppingCartBookManager.GetAll()
				.Where(s => s.ShoppingCartId == shoppingCartId).ToList();


			var bookId = shoppingCartBooks.Select(scb => scb.BookId).ToList();
			var books = _bookManager.GetAll()
				.Where(b => bookId.Contains(b.Id))
				.ToDictionary(b => b.Id);


			

			double totalPrice = 0;

			foreach (var item in shoppingCartBooks)
			{
				if (books.TryGetValue(item.BookId, out var book))
				{
					item.Book = book;
					totalPrice += book.Price;
				}
			}


			if (ModelState.IsValid)
			{
				OrderDto dto = new OrderDto
				{
					OrderDate = DateTime.Now,
					AppUserId = userId,
					//ShoppingCartId = shoppingCartId,
					TotalPrice = totalPrice


				};

				_orderManager.Create(dto);
			}


			//if (shoppingCartBooks is not null)
			//{
			//	foreach (var item in shoppingCartBooks)
			//	{
			//		_shoppingCartBookManager.Delete(item);
			//	}
			//}

			if (shoppingCartBooks is not null)
			{
				foreach (var item in shoppingCartBooks)
				{
					// Varlığı silmeden önce izlenip izlenmedigi kontrolü
					var existingEntity = _shoppingCartBookManager.GetAll()
						.FirstOrDefault(scb => scb.Id == item.Id);

					if (existingEntity != null)
					{
						_shoppingCartBookManager.Delete(existingEntity);
					}
				}
			}



			TempData["Message"] = "Teşekkürler siparişiniz alınmıştır, siparişlerim bölümünden inceleyebilirsiniz";

			return RedirectToAction("Index");
		}




	}
}
