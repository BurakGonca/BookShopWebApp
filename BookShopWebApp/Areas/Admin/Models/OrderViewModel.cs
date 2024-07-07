using BookShopWebApp.Areas.Admin.Models;

namespace BookShopWebApp.Areas.Models
{
	public class OrderViewModel
	{
		public int Id { get; set; }


		public DateTime OrderDate { get; set; }


		public double TotalPrice { get; set; }


		//iliskiler

		public int PaymentId { get; set; }
		public PaymentViewModel Payment { get; set; }



		public int UserId { get; set; }
		public UserViewModel User { get; set; }



		public int ShoppingCartId { get; set; }
		public ShoppingCartViewModel ShoppingCart { get; set; }


		public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }


		public int RowNum { get; set; }
	}
}
