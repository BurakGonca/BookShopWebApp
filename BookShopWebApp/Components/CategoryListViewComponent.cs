using BookShopWebApp.Models;
using BS.DAL.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShopWebApp.Components
{
    public class CategoryListViewComponent : ViewComponent
    {

        private readonly CategoryService _categoryService;

        public CategoryListViewComponent(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


		//public IViewComponentResult Invoke()
		//{
		//	return View(_categoryService.GetAll());
		//}


        public IViewComponentResult Invoke()
        {
            var categoryViewModels = _categoryService.GetAll()
                .Select(categoryDto => new CategoryViewModel
                {
                    CategoryName = categoryDto.CategoryName 
                })
                .ToList();

            return View(categoryViewModels);
        }


    }
}
