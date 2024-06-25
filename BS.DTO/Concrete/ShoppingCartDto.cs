using BS.DTO.Abstract;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class ShoppingCartDto : BaseDto
	{

		public double? TotalPrice { get; set; }
		public bool? IsActive { get; set; }




		//iliskiler

		public OrderDto? Order { get; set; }

		public IEnumerable<ShoppingCartBookDto>? ShoppingCartBooks { get; set; }
		public int AppUserId { get; set; }
		public AppUserDto? AppUser { get; set; }

	}
}
