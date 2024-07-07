using AutoMapper;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Profiles
{
	public class ShoppingCartBookProfile : Profile
	{
        
        public ShoppingCartBookProfile()
        {
            CreateMap<ShoppingCartBook, ShoppingCartBookDto>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));
            CreateMap<ShoppingCartBookDto, ShoppingCartBook>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));

            CreateMap<ShoppingCartBook, ShoppingCartBookDto>().ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart));
            CreateMap<ShoppingCartBookDto, ShoppingCartBook>().ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart));

            CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();
            CreateMap<BookDto, Book>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();

            CreateMap<Book, BookDto>().ForMember(dest => dest.Comments, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.Comments, opt => opt.Ignore());

            CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            CreateMap<Book, BookDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore());

            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.Order, opt => opt.Ignore());
            CreateMap<ShoppingCartDto, ShoppingCart>().ForMember(dest => dest.Order, opt => opt.Ignore());

            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore());
            CreateMap<ShoppingCartDto, ShoppingCart>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore());

            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore());
            CreateMap<ShoppingCartDto, ShoppingCart>().ForMember(dest => dest.AppUser, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>().ReverseMap();






            CreateMap<ShoppingCartBookDto, ShoppingCartBook>()
            //.ForMember(dest => dest.Id, opt => opt.Ignore()) //silme işleminde ıd'yi yakalamamı engelliyordu
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
            .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart));

            CreateMap<ShoppingCartBook, ShoppingCartBookDto>();





        }




    }
}
