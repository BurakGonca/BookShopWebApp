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
	public class PaymentProfile : Profile
	{

        public PaymentProfile()
        {
            CreateMap<AppUser, AppUserDto>()
                           .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                           .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart))
                           .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                           .ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
                .ReverseMap();


            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ReverseMap();


            CreateMap<ShoppingCart, ShoppingCartDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))

                .ReverseMap();

            CreateMap<Payment, PaymentDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))

                .ReverseMap();

        }

    }
}
