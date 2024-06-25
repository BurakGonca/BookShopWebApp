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
	public class ShoppingCartBookRepo : Repo<ShoppingCartBook>
	{

		public ShoppingCartBookRepo(BSDbContext dbContext) : base(dbContext)
		{



		}


		//public override ShoppingCartBook? GetById(int id)
		//{
		//	return _dbContext.ShoppingCarts.Include(x => x.B).Where(x => x.Id == id).SingleOrDefault();
		//}


	}
}
