using AutoMapper;
using BookShopWebApp.Areas.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
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




				configuration.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Books, y => y.MapFrom(z => z.Books));


				configuration.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();

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
				BookViewModel bookView = new BookViewModel();
				bookView = _mapper.Map<BookViewModel>(bookDto);
				models.Add(bookView);
				bookView.RowNum = _rowNum++;
			}



			return View(models);


		}





		[HttpGet]
		public IActionResult Create()
		{
			BookViewModel viewModel = new BookViewModel();

			List<CategoryDto> categoryDtos = _categoryManager.GetAll().ToList();


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



		[HttpGet]
		public IActionResult Delete(int id)
		{
			BookDto bookDto = _bookManager.GetById(id);
			BookViewModel bookViewModel = _mapper.Map<BookViewModel>(bookDto);
			return View(bookViewModel);
		}

		[HttpPost]
		public IActionResult Delete(BookViewModel model)
		{

			BookDto dto = _mapper.Map<BookDto>(model);
			_bookManager.Delete(dto);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Edit(int id)
		{
			BookDto dto = _bookManager.GetById(id);


			BookViewModel viewModel = _mapper.Map<BookViewModel>(dto);


			//kategori listesi için

			List<CategoryDto> categoryDtos = _categoryManager.GetAll().ToList();


			List<SelectListItem> categoryList = new List<SelectListItem>();

			foreach (CategoryDto categoryDto in categoryDtos)
			{
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.Text = categoryDto.CategoryName;
				selectListItem.Value = categoryDto.Id.ToString();

				categoryList.Add(selectListItem);
			}

			ViewBag.CategoryList = categoryList;


			if (viewModel.ImageName == null)
			{
				viewModel.ImageName = dto.ImageName;

			}
			ViewBag.PicName = viewModel.ImageName;

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Edit(BookViewModel model)
		{
			if (model.ImageFile is null)
			{
				ModelState.Remove<BookViewModel>(m => m.ImageFile);
			}



			if (ModelState.IsValid)
			{
				if (model.ImageFile != null && model.ImageFile.Name != model.ImageName)
				{
					model.ImageName = model.ImageFile.FileName;

					var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.ImageFile.FileName);


					var akisOrtami = new FileStream(konum, FileMode.Create);

					//Resmi kaydet
					model.ImageFile.CopyTo(akisOrtami);
				}
				BookDto dto = _mapper.Map<BookDto>(model);
				_bookManager.Update(dto);
				return RedirectToAction("Index");
			}
			return View();
		}


	}
}
