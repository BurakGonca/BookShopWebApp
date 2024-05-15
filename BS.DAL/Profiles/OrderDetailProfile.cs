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
	public class OrderDetailProfile : Profile
	{

        public OrderDetailProfile()
        {
			CreateMap<OrderDetailDto, OrderDetail>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));
			CreateMap<OrderDetail, OrderDetailDto>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));
			

			CreateMap<BookDto, Book>().ReverseMap();

		}
        


	}
}
