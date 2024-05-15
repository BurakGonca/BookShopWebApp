using BS.DAL.Context;
using BS.DAL.Repositories.Abtract;
using BS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Repositories.Concrete
{
	public class ShoppingCartRepo : Repo<ShoppingCart>
	{
		public ShoppingCartRepo(BSDbContext dbContext) : base(dbContext)
		{
		}


		public override ShoppingCart? GetById(int id)
		{
			return _dbContext.ShoppingCarts.Include(x => x.User).Where(x => x.Id == id).SingleOrDefault();
		}

	}
}
