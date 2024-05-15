using AutoMapper;
using BS.DAL.Profiles;
using BS.DAL.Repositories.Abtract;
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
	public class ShoppingCartService : Service<ShoppingCart, ShoppingCartDto>
	{
		public ShoppingCartService(ShoppingCartRepo repo) : base(repo)
		{
			MapperConfiguration config = new MapperConfiguration(config => {
				Profile profile = new ShoppingCartProfile();
				config.AddProfile(profile);
			});

			base.Mapper = config.CreateMapper();

		}
	}
}
