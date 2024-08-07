﻿using BS.DTO.Abstract;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class OrderDto : BaseDto
	{
		public DateTime OrderDate { get; set; }


        //sonradan eklediğim kolon
        public double TotalPrice { get; set; }


        //iliskiler

        public int? PaymentId { get; set; }
		public PaymentDto? Payment { get; set; }



		public int AppUserId { get; set; }
		public AppUserDto? AppUser { get; set; }



		public int? ShoppingCartId { get; set; }
		public ShoppingCartDto? ShoppingCart { get; set; }


				


		public IEnumerable<OrderDetail>? OrderDetails { get; set; }

	}
}
