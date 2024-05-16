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
	public class UserDto : BaseDto
	{

		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public Gender Gender { get; set; }


		//iliskiler


		public IQueryable<CommentDto>? Comments { get; set; }


		public IQueryable<OrderDto>? Orders { get; set; }


		public IQueryable<ShoppingCartDto> ShoppingCarts { get; set; }


		public IQueryable<OrderDetailDto> OrderDetails { get; set; }


	}
}
