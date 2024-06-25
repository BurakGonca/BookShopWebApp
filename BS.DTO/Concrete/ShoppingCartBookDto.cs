using BS.DTO.Abstract;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class ShoppingCartBookDto : BaseDto
	{

		public int ShoppingCartId { get; set; }
		public ShoppingCartDto? ShoppingCart { get; set; }


		public int BookId { get; set; }
		public BookDto? Book { get; set; }

	}
}
