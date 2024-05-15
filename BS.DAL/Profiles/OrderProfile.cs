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
	public class OrderProfile : Profile
	{
        public OrderProfile()
        {

			CreateMap<Order, OrderDto>()
				.ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
				.ForMember(dest => dest.ShoppingCartId, opt => opt.MapFrom(src => src.ShoppingCartId))
				.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
				.ReverseMap();


		}

    }
}
