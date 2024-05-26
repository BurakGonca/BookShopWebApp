using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Repositories.Abtract
{
    public interface IUserRepo
    {

        User? FindLoginUser(string username, string password);
    }
}
