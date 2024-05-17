using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class Category : BaseEntity
	{

        public string CategoryName { get; set; }



        //iliskiler

        public IEnumerable<Book> Books { get; set; }

    }
}
