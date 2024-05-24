using AutoMapper;
using BookShopWebApp.Areas.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{

		private BookManager _bookManager;
		private CategoryManager _categoryManager;

		private IMapper _mapper;
		private int _rowNum = 1;

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
				categoryView.RowNum = _rowNum++;
			}



			return View(models);


			
		}
	}
}
