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

			

			CreateMap<Book, BookDto>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

			CreateMap<Book, BookDto>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

			CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

			CreateMap<CategoryDto, Category>().ReverseMap();
			CreateMap<CommentDto, Comment>().ReverseMap();
			CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();


			


		}

    }
}
