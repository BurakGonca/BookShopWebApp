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
	public class CategoryProfile : Profile
	{
        public CategoryProfile() 
        {

			CreateMap<Category, CategoryDto>().ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
			CreateMap<CategoryDto, Category>().ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

			//CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
			//CreateMap<BookDto, Book>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Book, BookDto>().ForMember(dest => dest.Comments, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.Comments, opt => opt.Ignore());

            CreateMap<Book, BookDto>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            /*

			ClassA.Integer.Age		=> ClassB.Integer.Age
			ClassA.Boolean.IsActive => ClassB.Boolean.IsActive
			ClassA.String.Name		=> ClassB.String.Name

			ClassA.ClassC.Lesson	=> ClassB.ClassD.Lesson
			 
			 */


            CreateMap<CategoryDto, Category>().ReverseMap();






            CreateMap<CategoryDto, Category>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.Books, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>();


        }


    }

}
