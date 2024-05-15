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
	public class CategoryRepo : Repo<Category>
	{
		public CategoryRepo(BSDbContext dbContext) : base(dbContext)
		{
		}

		public override IQueryable<Category> GetAll()
		{
			
			return _dbContext.Categories.Include(c=>c.Books);
		}



	}
}
