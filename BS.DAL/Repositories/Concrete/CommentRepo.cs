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
	public class CommentRepo : Repo<Comment>
	{
		public CommentRepo(BSDbContext dbContext) : base(dbContext)
		{
		}

		public override Comment? GetById(int id)
		{
			return _dbContext.Comments.Include(x => x.User).Where(x => x.Id == id).SingleOrDefault();
		}




	}
}
