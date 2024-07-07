using AutoMapper;
using BS.DAL.Context;
using BS.DAL.Profiles;
using BS.DAL.Repositories.Concrete;
using BS.DAL.Services.Abstract;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Services.Concrete
{
	public class ShoppingCartBookService :Service<ShoppingCartBook, ShoppingCartBookDto>
	{
        
        public ShoppingCartBookService(ShoppingCartBookRepo repo) : base(repo)
		{
			MapperConfiguration config = new MapperConfiguration(config => {
				Profile profile = new ShoppingCartBookProfile();
				config.AddProfile(profile);
			});

			base.Mapper = config.CreateMapper();

		}

	}
}
