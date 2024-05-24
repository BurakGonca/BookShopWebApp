namespace BookShopWebApp.Areas.Models
{
	public class ShoppingCartViewModel
	{

		public int Id { get; set; }

		public double TotalPrice { get; set; }
		public bool IsActive { get; set; }




		//iliskiler

		public OrderViewModel Order { get; set; }


		//public IQueryable<Book> Books { get; set; }


		//public int UserId { get; set; }
		//public UserViewModel User { get; set; }

		public int RowNum { get; set; }
	}
}
