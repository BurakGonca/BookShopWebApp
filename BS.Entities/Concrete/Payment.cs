using BS.Entities.Abstract;
using BS.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class Payment : BaseEntity
	{
		public PaymentMethod PaymentMethod { get; set; }
		public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }


        //iliskiler

        public int UserId { get; set; }
        public User User { get; set; }


        public Order Order { get; set; }





    }
}
