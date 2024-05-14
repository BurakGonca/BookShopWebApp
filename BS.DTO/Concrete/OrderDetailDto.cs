using BS.DTO.Abstract;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class OrderDetailDto : BaseDto
	{

		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }
		public double TotalPrice { get; set; }




		//iliskiler


		public int OrderId { get; set; }
		public OrderDto Order { get; set; }


		
		public int UserId { get; set; }
		public UserDto User { get; set; }


		public int BookId { get; set; }
		public BookDto Book { get; set; }


	}
}
