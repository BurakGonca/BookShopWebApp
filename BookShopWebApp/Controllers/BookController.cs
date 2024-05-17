using AutoMapper;
using BookShopWebApp.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWebApp.Controllers
{
	public class BookController : Controller
	{
		private BookManager _bookManager;
		private CategoryManager _categoryManager;
		
		private IMapper _mapper;
		private int _rowNum = 1;

		public BookController(BookManager bookManager, CategoryManager categoryManager)
		{
			_bookManager = bookManager;

			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{

				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
				configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));

				configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();
			});
			_mapper = configuration.CreateMapper();

			_categoryManager = categoryManager;
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

			List<CategoryDto> categoryDtos = _categoryManager.GetAll().ToList();

			//List<CategoryViewModel> categoryList = new List<CategoryViewModel>();

			//foreach (CategoryDto categoryDtp in categoryDtos)
			//{
			//	CategoryViewModel markaView = new CategoryViewModel();
			//	markaView = _mapper.Map<CategoryViewModel>(categoryDtp);
			//	categoryList.Add(markaView);
			//	markaView.RowNum = _rowNum++;
			//}

			List<SelectListItem> categoryList = new List<SelectListItem>();

			foreach (CategoryDto categoryDto in categoryDtos)
			{
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.Text = categoryDto.CategoryName;
				selectListItem.Value = categoryDto.Id.ToString();

				categoryList.Add(selectListItem);
			}

			ViewBag.CategoryList = categoryList;

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Create(BookViewModel model)
		{

			ModelState.Remove<BookViewModel>(m => m.OrderDetails);
			ModelState.Remove<BookViewModel>(m => m.Comments);
			ModelState.Remove<BookViewModel>(m => m.Category);

			if (ModelState.IsValid)
			{

				if (model.ImageFile is not null)
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
