using AutoMapper;
using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWebApp.Controllers
{
	public class CategoryController : Controller
	{
		private BookManager _bookManager;
		private CategoryManager _categoryManager;
		private IMapper _mapper;

		public CategoryController(BookManager bookManager, CategoryManager categoryManager)
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

			});
			_mapper = configuration.CreateMapper();


		}

		public IActionResult Index()
		{
			List<CategoryDto> categoryDto = _categoryManager.GetAll().ToList();

			List<CategoryViewModel> models = new List<CategoryViewModel>();

			foreach (CategoryDto dto in categoryDto)
			{
				CategoryViewModel categoryView = new CategoryViewModel();
				categoryView = _mapper.Map<CategoryViewModel>(dto);
				models.Add(categoryView);

			}



			return View(models);
		}





		public IActionResult Books(int id, int page = 1, int pageSize = 4)
		{
			var categoryDto = _categoryManager.GetById(id);

			var booksDto = _bookManager.GetAll().Where(b => b.CategoryId == id).ToList();
			var booksViewModel = _mapper.Map<List<BookViewModel>>(booksDto);


			var totalBooks = booksViewModel.Count;

			// Toplam sayfa sayısını hesaplama
			var totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

			// Mevcut sayfa numarasını kontrol
			if (page < 1)
				page = 1;

			else if (page > totalPages)
				page = totalPages;


			// Mevcut sayfaya göre kitapları filtreleme
			var currentPageBooks = booksViewModel.Skip((page - 1) * pageSize).Take(pageSize).ToList();

			var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
			categoryViewModel.Books = currentPageBooks;
			categoryViewModel.CurrentPage = page;
			categoryViewModel.TotalPages = totalPages;

			return View(categoryViewModel);
		}






	}
}
