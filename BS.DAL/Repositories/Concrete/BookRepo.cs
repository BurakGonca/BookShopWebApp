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
	public class BookRepo : Repo<Book>
	{
		public BookRepo(BSDbContext dbContext) : base(dbContext)
		{


		}

		public override IQueryable<Book> GetAll()
		{
			return _dbContext.Books.Include(b => b.OrderDetails).Include(b=>b.Category);


		}

		
		public override Book? GetById(int id)
		{
			return _dbContext.Books.Include(x => x.Category).Where(x => x.Id == id).SingleOrDefault();
		}



	}
}
