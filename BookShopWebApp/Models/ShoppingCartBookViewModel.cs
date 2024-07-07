
namespace BookShopWebApp.Models
{
	public class ShoppingCartBookViewModel
	{

		public int ShoppingCartId { get; set; }
		public ShoppingCartViewModel? ShoppingCart { get; set; }


		public int BookId { get; set; }
		public BookViewModel? Book { get; set; }



		//yardımcı

		public int Id { get; set; }


	}
}
