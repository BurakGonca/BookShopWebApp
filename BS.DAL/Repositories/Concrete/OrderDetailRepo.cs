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
	public class OrderDetailRepo : Repo<OrderDetail>
	{
		public OrderDetailRepo(BSDbContext dbContext) : base(dbContext)
		{
		}


		public override OrderDetail? GetById(int id)
		{
			return _dbContext.OrderDetails.Include(x => x.Book).Where(x => x.Id == id).SingleOrDefault();
		}


	}
}
