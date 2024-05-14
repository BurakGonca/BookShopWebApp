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
	public class BookProfile : Profile
	{
        public BookProfile()
        {

			CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
			CreateMap<BookDto, Book>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
			CreateMap<BookDto, Book>().ReverseMap();
			CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();

		}

    }
}
