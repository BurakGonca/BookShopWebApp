using BS.DAL.Context;
using BS.DAL.Repositories.Abtract;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Repositories.Concrete
{
	public class PaymentRepo : Repo<Payment>
	{
		public PaymentRepo(BSDbContext dbContext) : base(dbContext)
		{
		}


		public override Payment? GetById(int id)
		{
			return _dbContext.Payments.Include(x => x.User).Where(x => x.Id == id).SingleOrDefault();
		}

	}
}
