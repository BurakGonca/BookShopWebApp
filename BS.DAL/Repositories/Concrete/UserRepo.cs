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
    public class UserRepo : Repo<User>, IUserRepo
	{
		public UserRepo(BSDbContext dbContext) : base(dbContext)
		{

		}

       

        public override IQueryable<User> GetAll()
		{
			return _dbContext.Users.Include(b => b.Orders);


		}


        public User? FindLoginUser(string username, string password)
        {
            return base._dbContext.Users
                .Where(u=>u.Email == username && u.Password == password)
                .SingleOrDefault();
        }


    }
}
