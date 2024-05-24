using AutoMapper;
using BookShopWebApp.Areas.Models;
using BS.BLL.Managers.Concrete;
using BS.DTO.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryDto categoryDto = _categoryManager.GetById(id);
            CategoryViewModel categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
            return View(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CategoryViewModel model)
        {


            CategoryDto dto = _mapper.Map<CategoryDto>(model);

            _categoryManager.Delete(dto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryDto dto = _categoryManager.GetById(id);

            CategoryViewModel viewModel = _mapper.Map<CategoryViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                
                CategoryDto dto = _mapper.Map<CategoryDto>(model);
                _categoryManager.Update(dto);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
