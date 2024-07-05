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
	public class ShoppingCartProfile : Profile
	{
		public ShoppingCartProfile()
		{

			CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order)).ReverseMap();
			CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.MapFrom(src => src.ShoppingCartBooks)).ReverseMap();
			CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser)).ReverseMap();

            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)).ReverseMap();
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders)).ReverseMap();
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart)).ReverseMap();
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)).ReverseMap();




            CreateMap<Order, OrderDto>().ForMember(dest => dest.Payment, opt => opt.Ignore()).ReverseMap();
            CreateMap<Order, OrderDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            CreateMap<Order, OrderDto>().ForMember(dest => dest.ShoppingCart, opt => opt.Ignore()).ReverseMap();
            CreateMap<Order, OrderDto>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();


            CreateMap<ShoppingCartBook, ShoppingCartBookDto>().ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart)).ReverseMap();
            CreateMap<ShoppingCartBook, ShoppingCartBookDto>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book)).ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartDto>();





            //CreateMap<AppUser, AppUserDto>()
            //   .ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            //CreateMap<AppUser, AppUserDto>()
            //   .ForMember(dest => dest.ShoppingCart, opt => opt.Ignore()).ReverseMap();
            //CreateMap<AppUser, AppUserDto>()
            //   .ForMember(dest => dest.Orders, opt => opt.Ignore()).ReverseMap();
            //CreateMap<AppUser, AppUserDto>()
            //   .ForMember(dest => dest.Comments, opt => opt.Ignore()).ReverseMap();



            //CreateMap<Order, OrderDto>()
            //	.ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Order, OrderDto>()
            //	.ForMember(dest => dest.ShoppingCart, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Order, OrderDto>()
            //	.ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Order, OrderDto>()
            //	.ForMember(dest => dest.Payment, opt => opt.Ignore()).ReverseMap();




            //CreateMap<ShoppingCartBook, ShoppingCartBookDto>()
            //   .ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();
            //CreateMap<ShoppingCartBook, ShoppingCartBookDto>()
            //   .ForMember(dest => dest.ShoppingCart, opt => opt.Ignore()).ReverseMap();







            //         CreateMap<ShoppingCartDto, ShoppingCart>()
            //         .ForMember(dest => dest.Id, opt => opt.Ignore())
            //         .ForMember(dest => dest.AppUser, opt => opt.Ignore())
            //         .ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore())
            //         .ForMember(dest => dest.Order, opt => opt.Ignore());

            //         CreateMap<ShoppingCart, ShoppingCartDto>();

        }

    }
}
