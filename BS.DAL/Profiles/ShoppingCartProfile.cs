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
			CreateMap<ShoppingCart, ShoppingCartDto>()
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
				.ReverseMap();
		}

    }
}
