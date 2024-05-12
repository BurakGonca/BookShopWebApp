using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class ShoppingCart : BaseEntity
	{
		public double TotalPrice { get; set; }
        public bool IsActive { get; set; }




        //iliskiler

        public Order Order { get; set; }


		public IQueryable<Book> Books { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

    }
}
