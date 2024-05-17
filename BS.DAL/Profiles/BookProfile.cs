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

			

			CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
			CreateMap<Book, BookDto>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
			CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<BookDto, Book>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<BookDto, Book>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<BookDto, Book>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<CategoryDto, Category>().ForMember(dest => dest.Books,  opt => opt.Ignore()).ReverseMap();
			CreateMap<CommentDto, Comment>().ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();
			CreateMap<OrderDetailDto, OrderDetail>().ForMember(dest =>dest.Book, opt => opt.Ignore()).ReverseMap();


			


		}

    }
}
