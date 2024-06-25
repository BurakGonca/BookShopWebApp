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
			//CreateMap<AppUser, AppUserDto>()
			//   .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
			//   .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart))
			//   .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
			//   .ReverseMap();

			CreateMap<Book, BookDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore()).ReverseMap();
			CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
			CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.Ignore()).ReverseMap();
			CreateMap<Book, BookDto>().ForMember(dest => dest.Comments, opt => opt.Ignore()).ReverseMap();


            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore()).ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.Order, opt => opt.Ignore()).ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
        

            //CreateMap<ShoppingCartBook, ShoppingCartBookDto>()
            //   .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
            //   .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart))
            //   .ReverseMap();


     


        }



	}
}
