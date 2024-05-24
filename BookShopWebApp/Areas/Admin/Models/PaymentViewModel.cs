using BS.Enums;

namespace BookShopWebApp.Areas.Models
{
	public class PaymentViewModel
	{

		public int Id { get; set; }


		public PaymentMethod PaymentMethod { get; set; }
		public DateTime PaymentDate { get; set; }
		public PaymentStatus PaymentStatus { get; set; }


		//iliskiler

		public int UserId { get; set; }
		public UserViewModel User { get; set; }


		public OrderViewModel Order { get; set; }


		public int RowNum { get; set; }
	}
}
