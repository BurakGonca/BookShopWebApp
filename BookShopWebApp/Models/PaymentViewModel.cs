﻿using BS.Enums;

namespace BookShopWebApp.Models
{
	public class PaymentViewModel
	{

		public int Id { get; set; }


		public PaymentMethod PaymentMethod { get; set; }
		public DateTime PaymentDate { get; set; }
		public PaymentStatus PaymentStatus { get; set; }


		//iliskiler

		public int UserId { get; set; }
		public AppUserViewModel User { get; set; }


		public OrderViewModel Order { get; set; }


		public int RowNum { get; set; }
	}
}
