namespace BookShopWebApp.Models
{
	public class OrderDetailViewModel
	{
		public int Id { get; set; }


		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }
		public double TotalPrice { get; set; }




		//iliskiler


		public int OrderId { get; set; }
		public OrderViewModel Order { get; set; }




		public int UserId { get; set; }
		public AppUserViewModel User { get; set; }


		public int BookId { get; set; }
		public BookViewModel Book { get; set; }



		public int RowNum { get; set; }
	}
}
