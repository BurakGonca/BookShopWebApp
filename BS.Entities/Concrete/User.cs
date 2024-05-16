using BS.Entities.Abstract;
using BS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class User : BaseEntity
	{

		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public Gender Gender { get; set; }


        //iliskiler


        public IQueryable<Comment>? Comments { get; set; }


        public IQueryable<Order>? Orders { get; set; }


        public IQueryable<ShoppingCart> ShoppingCarts { get; set; }


        public IQueryable<OrderDetail> OrderDetails { get; set; }





    }
}
