using BS.DTO.Abstract;
using BS.Entities.Concrete;
using BS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class PaymentDto : BaseDto
	{

		public PaymentMethod PaymentMethod { get; set; }
		public DateTime PaymentDate { get; set; }
		public PaymentStatus PaymentStatus { get; set; }


		//iliskiler

		public int UserId { get; set; }
		public UserDto User { get; set; }


		public OrderDto Order { get; set; }


	}
}
