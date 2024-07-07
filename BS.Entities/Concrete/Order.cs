using BS.Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class Order : BaseEntity
    {
       



        public DateTime OrderDate { get; set; }

		//sonradan eklediğim kolon
		public double TotalPrice { get; set; }



		//iliskiler

		public int? PaymentId { get; set; }
        public Payment Payment { get; set; }



        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }



        public int? ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }


        public IEnumerable<OrderDetail>? OrderDetails { get; set; }


    }
}
