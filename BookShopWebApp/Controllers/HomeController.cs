using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;

namespace BookShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private BookManager _bookManager;
		private CategoryManager _categoryManager;

		private IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, BookManager bookManager, CategoryManager categoryManager)
		{
			_logger = logger;
			_bookManager = bookManager;
			_categoryManager = categoryManager;

			

			MapperConfiguration configuration = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<BookDto, BookViewModel>()
					.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
					.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
					.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
				cfg.CreateMap<BookViewModel, BookDto>()
					.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
					.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
					.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

				cfg.CreateMap<CategoryDto, CategoryViewModel>()
					.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
				cfg.CreateMap<CategoryViewModel, CategoryDto>()
					.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
			});

			_mapper = configuration.CreateMapper();


		}

		public IActionResult Index()
		{
			List<BookDto> bookDtos = _bookManager.GetAll().Take(4).ToList();

			List<BookViewModel> models = new List<BookViewModel>();

			foreach (BookDto bookDto in bookDtos)
			{
				BookViewModel bookView = new BookViewModel();
				bookView = _mapper.Map<BookViewModel>(bookDto);
				models.Add(bookView);

			}



			return View(models);


			

		}

		public IActionResult About()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
