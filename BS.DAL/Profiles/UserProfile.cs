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
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
				.ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
				.ForMember(dest => dest.ShoppingCarts, opt => opt.MapFrom(src => src.ShoppingCarts))
				.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
				.ReverseMap();


		}

	}
}
