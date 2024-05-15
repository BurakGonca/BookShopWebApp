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

			
						
			CreateMap<CategoryDto, Category>().ReverseMap();



		}


    }

}
