using AutoMapper;
using BookShopWebApp.Models;
using BookShopWebApp.Models.HelperModels;
using BS.BLL.Managers.Concrete;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Controllers
{
	public class BookController : Controller
	{

		private BookManager _bookManager;
		private CategoryManager _categoryManager;

		private IMapper _mapper;

		public BookController(BookManager bookManager, CategoryManager categoryManager)
		{
			_bookManager = bookManager;
			_categoryManager = categoryManager;
			


			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{

				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
				configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();


				configuration.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Books, y => y.MapFrom(z => z.Books));
				configuration.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();


				configuration.CreateMap<BookListViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookListViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
				configuration.CreateMap<BookListViewModel, BookDto>().ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
				configuration.CreateMap<BookListViewModel, BookDto>().ReverseMap();



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


		//public IActionResult Index(int page = 1, int pageSize = 4)
		//{
		//	var categoryDto = _categoryManager.GetAll();

		//	var booksDto = _bookManager.GetAll().ToList();
		//	var booksViewModel = _mapper.Map<List<BookViewModel>>(booksDto);


		//	var totalBooks = booksViewModel.Count;

		//	Toplam sayfa sayısını hesaplama
		//	var totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

		//	Mevcut sayfa numarasını kontrol
		//	if (page < 1)
		//		page = 1;

		//	else if (page > totalPages)
		//		page = totalPages;


		//	Mevcut sayfaya göre kitapları filtreleme
		//   var currentPageBooks = booksViewModel.Skip((page - 1) * pageSize).Take(pageSize).ToList();

		//	var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
		//	categoryViewModel.Books = currentPageBooks;
		//	categoryViewModel.CurrentPage = page;
		//	categoryViewModel.TotalPages = totalPages;

		//	return View(categoryViewModel);
		//}













	}





}

