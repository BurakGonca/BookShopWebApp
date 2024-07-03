using AutoMapper;
using BookShopWebApp.Models;
using BookShopWebApp.Models.HelperModels;
using BS.BLL.Managers.Concrete;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        //public BookController(BookManager bookManager, CategoryManager categoryManager, UserManager<AppUser> userManager, ShoppingCartManager shoppingCartManager, ShoppingCartBookManager shoppingCartBookManager)
        //{
        //    _bookManager = bookManager;
        //    _categoryManager = categoryManager;
        //    _userManager = userManager;
        //    _shoppingCartManager = shoppingCartManager;
        //    _shoppingCartBookManager = shoppingCartBookManager;

        //    MapperConfiguration configuration = new MapperConfiguration(configuration =>
        //    {
        //        configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
        //        configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
        //        configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
        //        configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
        //        configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();




        //        configuration.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Books, y => y.MapFrom(z => z.Books));
        //        configuration.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();

        //        configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
        //        configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
        //        configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();


        //        // Yeni mappingler
        //        configuration.CreateMap<BookDto, Book>().ReverseMap();
        //        configuration.CreateMap<CategoryDto, Category>().ReverseMap();
        //        configuration.CreateMap<ShoppingCartDto, ShoppingCart>().ReverseMap();
        //        configuration.CreateMap<ShoppingCartBookDto, ShoppingCartBook>().ReverseMap();

        //        configuration.CreateMap<ShoppingCartBookViewModel, ShoppingCartBookDto>().ReverseMap();





        //    });




        //    _mapper = configuration.CreateMapper();

        //    //_mapper.ConfigurationProvider.AssertConfigurationIsValid();
        //}


        public BookController(BookManager bookManager, CategoryManager categoryManager, UserManager<AppUser> userManager, ShoppingCartManager shoppingCartManager, ShoppingCartBookManager shoppingCartBookManager)
        {
            _bookManager = bookManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
            _shoppingCartManager = shoppingCartManager;
            _shoppingCartBookManager = shoppingCartBookManager;

            MapperConfiguration configuration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments));
                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails));
                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
                configuration.CreateMap<BookViewModel, BookDto>().ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
                configuration.CreateMap<BookViewModel, BookDto>().ReverseMap();

                configuration.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Books, y => y.MapFrom(z => z.Books));
                configuration.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();

                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.AppUser, y => y.MapFrom(z => z.User));
                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ForMember(x => x.ShoppingCartBooks, y => y.MapFrom(z => z.ShoppingCartBooks));
                configuration.CreateMap<ShoppingCartViewModel, ShoppingCartDto>().ReverseMap();

                // Yeni mappingler
                configuration.CreateMap<BookDto, Book>().ReverseMap();
                configuration.CreateMap<CategoryDto, Category>().ReverseMap();
                configuration.CreateMap<ShoppingCartDto, ShoppingCart>().ReverseMap();
                configuration.CreateMap<ShoppingCartBookDto, ShoppingCartBook>().ReverseMap();

                configuration.CreateMap<ShoppingCartBookViewModel, ShoppingCartBookDto>().ReverseMap();
            });

            _mapper = configuration.CreateMapper();

            //_mapper.ConfigurationProvider.AssertConfigurationIsValid();
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

            ViewBag.AddToCart = false;

            if (TempData.ContainsKey("AddToCart"))
            {
                bool addToCart = (bool)TempData["AddToCart"];
                ViewBag.ModalMessage = TempData["ModalMessage"].ToString();
                ViewBag.AddToCart = addToCart;
            }


			return View(bookListModel);
		}




        /// <summary>
        /// Kitap kartlarının üzerinde bulunan sepete ekle butonuna basınca kitabın Id'si ile login olan kullanıcının idsi üzerinden shoppingcartbook cross tablosuna insert edilmektedir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddToCart(int id)
        {
            // Sisteme login olan kullanıcının ID'sini veriyor
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            //her kullanıcı insert edilirken kendisine bir shoppingcart da insert etmistim
            var shoppingCart = _shoppingCartManager.GetAll().FirstOrDefault(s => s.AppUserId == userId);

                        
            var shoppingCartId = shoppingCart.Id;

            TempData["AddToCart"] = false;

            if (ModelState.IsValid)
            {
                
                ShoppingCartBookDto dto = new ShoppingCartBookDto
                {
                    ShoppingCartId = shoppingCartId,
                    BookId = id,
                    
                };

                
                _shoppingCartBookManager.Create(dto);

                BookDto bookDto =  _bookManager.GetById(id);

                TempData["AddToCart"] = true;
                TempData["ModalMessage"] = bookDto.BookName + " adlı kitap sepetinize başarıyla eklenmiştir. " + DateTime.Now.ToString();
            }

            return RedirectToAction(nameof(Index));
        }










    }





}

