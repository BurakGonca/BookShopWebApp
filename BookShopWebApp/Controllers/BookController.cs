using AutoMapper;
using BookShopWebApp.Models;
using BookShopWebApp.Models.HelperModels;
using BS.BLL.Managers.Concrete;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShopWebApp.Controllers
{
	public class BookController : Controller
	{

		private BookManager _bookManager;
		private CategoryManager _categoryManager;
		private UserManager<AppUser> _userManager;
		private ShoppingCartManager _shoppingCartManager;
		private ShoppingCartBookManager _shoppingCartBookManager;
	

		private IMapper _mapper;

		public BookController(BookManager bookManager, CategoryManager categoryManager, UserManager<AppUser> userManager, ShoppingCartManager shoppingCartManager, ShoppingCartBookManager shoppingCartBookManager)
		{
			_bookManager = bookManager;
			_categoryManager = categoryManager;
			_userManager = userManager;
			_shoppingCartManager = shoppingCartManager;
			_shoppingCartBookManager = shoppingCartBookManager;

			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{

				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
				configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();


				configuration.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Books, y => y.MapFrom(z => z.Books));
				configuration.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();


				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));

				configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();



			});
			_mapper = configuration.CreateMapper();
			
		}








		public IActionResult Index(int page = 1, int pageSize = 12)
		{
			var booksDto = _bookManager.GetAll().ToList();
			var booksViewModel = _mapper.Map<List<BookViewModel>>(booksDto);

			var totalBooks = booksViewModel.Count;

			var totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

			if (page < 1)
				page = 1;
			else if (page > totalPages)
				page = totalPages;

			var currentPageBooks = booksViewModel.Skip((page - 1) * pageSize).Take(pageSize).ToList();

			var bookListModel = new BookListViewModel
			{
				Books = currentPageBooks,
				CurrentPage = page,
				TotalPages = totalPages
			};




			return View(bookListModel);
		}



		public IActionResult AddToCart(int id)
		{
            


            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User)); //sisteme login olanın id'sini verir.

			var denemeler = _shoppingCartManager.GetAll().ToList(); //maplemeyi deneme amacli yazdım.

			//ilk parametresi gelsin diye [0] yazdik.
			var shoppingCartId = _shoppingCartManager.GetAll().Where((s => s.AppUserId == userId)).ToList()[0].Id; 

			ShoppingCartBookViewModel model = new ShoppingCartBookViewModel();

			model.BookId = id;
			model.ShoppingCartId = shoppingCartId;

			


		

			if (ModelState.IsValid)
			{
				ShoppingCartBookDto dto = new ShoppingCartBookDto();
				dto.ShoppingCartId = model.ShoppingCartId;
				dto.BookId = model.BookId;
				dto.ShoppingCart= _shoppingCartManager.GetById(shoppingCartId);
				dto.Book = _bookManager.GetById(id);



                _shoppingCartBookManager.Create(dto);

				//bu userid ye ait shoppingcartid sini bulacağım.
				//sonra da shoppingcartid ile methoda gelen ıd'yi kullanarak shopppinggcartbook inse

				return RedirectToAction(nameof(Index));
			}
			
			return View(model);
			

		}













	}





}

