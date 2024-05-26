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

			CreateMap<Payment, PaymentDto>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();
			CreateMap<PaymentDto, Payment>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();

        }

    }
}
