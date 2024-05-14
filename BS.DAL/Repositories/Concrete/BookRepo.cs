using BS.DAL.Context;
using BS.DAL.Repositories.Abtract;
using BS.Entities.Concrete;
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
		
		//override lar yapilacak.


	}
}
