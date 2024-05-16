using BS.Enums;

namespace BookShopWebApp.Models
{
	public class UserViewModel
	{
		public int Id { get; set; }

		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public Gender Gender { get; set; }


		//iliskiler


		public IQueryable<CommentViewModel>? Comments { get; set; }


		public IQueryable<OrderViewModel>? Orders { get; set; }


		public IQueryable<ShoppingCartViewModel> ShoppingCarts { get; set; }


		public IQueryable<OrderDetailViewModel> OrderDetails { get; set; }


		public int RowNum { get; set; }
	}
}
