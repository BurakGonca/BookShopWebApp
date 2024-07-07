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
			CreateMap<Book, BookDto>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.MapFrom(src => src.ShoppingCartBooks));

            CreateMap<BookDto, Book>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<BookDto, Book>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<BookDto, Book>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            CreateMap<BookDto, Book>().ForMember(dest => dest.ShoppingCartBooks, opt => opt.MapFrom(src => src.ShoppingCartBooks));

            CreateMap<CategoryDto, Category>().ForMember(dest => dest.Books,  opt => opt.Ignore()).ReverseMap();
			CreateMap<CommentDto, Comment>().ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();
			CreateMap<OrderDetailDto, OrderDetail>().ForMember(dest =>dest.Book, opt => opt.Ignore()).ReverseMap();
			CreateMap<ShoppingCartBookDto, ShoppingCartBook>().ForMember(dest =>dest.Book, opt => opt.Ignore()).ReverseMap();


			CreateMap<Category, CategoryDto>().ForMember(dest => dest.Books, opt => opt.Ignore()).ReverseMap();
			CreateMap<Comment, CommentDto>().ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();
			CreateMap<OrderDetail, OrderDetailDto>().ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();
			CreateMap<ShoppingCartBook, ShoppingCartBookDto>().ForMember(dest => dest.Book, opt => opt.Ignore()).ReverseMap();


			//buraya dikkat bunun yüzünden book/edit hata veriyor çünkü Idyi ignore ettiğim için

			//CreateMap<BookDto, Book>()
			//.ForMember(dest => dest.Id, opt => opt.Ignore())
			//.ForMember(dest => dest.Category, opt => opt.Ignore())
			//.ForMember(dest => dest.Comments, opt => opt.Ignore())
			//.ForMember(dest => dest.OrderDetails, opt => opt.Ignore())
			//.ForMember(dest => dest.ShoppingCartBooks, opt => opt.Ignore());

			CreateMap<Book, BookDto>();


        }

    }
}
