using BS.Entities.Abstract;
using BS.Entities.Enums;
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



        //iliskiler

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }



        public int UserId { get; set; }
        public User User { get; set; }



        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }



        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }



    }
}
