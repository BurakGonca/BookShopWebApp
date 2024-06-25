using BS.Entities.Concrete;

namespace BookShopWebApp.Models
{
	public class ShoppingCartViewModel
	{

		public int Id { get; set; }

		public double? TotalPrice { get; set; }
		public bool? IsActive { get; set; }




        //iliskiler

        public OrderViewModel? Order { get; set; }


		public IEnumerable<ShoppingCartBookViewModel>? ShoppingCartBooks { get; set; }


		public int UserId { get; set; }
		public UserViewModel? User { get; set; }

		
	}
}
