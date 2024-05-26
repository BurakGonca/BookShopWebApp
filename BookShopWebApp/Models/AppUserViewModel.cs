using BS.Enums;

namespace BookShopWebApp.Models
{
	public class AppUserViewModel
	{
		public int Id { get; set; }

		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public Gender Gender { get; set; }


		//iliskiler


		public IEnumerable<CommentViewModel>? Comments { get; set; }


		public IEnumerable<OrderViewModel>? Orders { get; set; }


		public IEnumerable<ShoppingCartViewModel> ShoppingCarts { get; set; }


		public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }


		public int RowNum { get; set; }
	}
}
