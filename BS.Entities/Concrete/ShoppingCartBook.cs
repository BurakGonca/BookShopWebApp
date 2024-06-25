using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class ShoppingCartBook : BaseEntity
	{
		public int ShoppingCartId { get; set; }
		public ShoppingCart ShoppingCart { get; set; }


		public int BookId { get; set; }
		public Book Book { get; set; }


	}
}
