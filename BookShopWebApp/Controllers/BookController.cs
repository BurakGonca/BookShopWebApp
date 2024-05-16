using AutoMapper;
using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookShopWebApp.Controllers
{
	public class BookController : Controller
	{
		private BookManager _bookManager;
		
		private IMapper _mapper;
		private int _rowNum = 1;

		public BookController(BookManager bookManager)
		{
			_bookManager = bookManager;

			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{

				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));

				configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();
			});
			_mapper = configuration.CreateMapper();


		}

		public IActionResult Index()
		{
			List<BookDto> bookDtos = _bookManager.GetAll().ToList();

			List<BookViewModel> models = new List<BookViewModel>();

			foreach (BookDto bookDto in bookDtos)
			{
				BookViewModel markaView = new BookViewModel();
				markaView = _mapper.Map<BookViewModel>(bookDto);
				models.Add(markaView);
				markaView.RowNum = _rowNum++;
			}
			return View(models);


		}





		[HttpGet]
		public IActionResult Create()
		{
			BookViewModel viewModel = new BookViewModel();
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Create(BookViewModel model)
		{

			ModelState.Remove<BookViewModel>(m => m.OrderDetails);
			ModelState.Remove<BookViewModel>(m => m.Comments);

			if (ModelState.IsValid)
			{

				if (model.ImageName is not null)
				{
					var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.ImageFile.FileName);
					model.ImageName = model.ImageFile.FileName;

					var akisOrtami = new FileStream(konum, FileMode.Create);


					model.ImageFile.CopyTo(akisOrtami);


				}

				BookDto dto = _mapper.Map<BookDto>(model);

				_bookManager.Create(dto);

				return RedirectToAction("Index");
			}

			return View(model);


			
			
		}









	}
}
