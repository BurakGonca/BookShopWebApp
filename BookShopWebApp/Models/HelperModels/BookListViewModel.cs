using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.HelperModels
{
	public class BookListViewModel
	{

		public List<BookViewModel> Books { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }



		//iliskiler

		public IEnumerable<CommentViewModel>? Comments { get; set; }
		public IEnumerable<OrderDetailViewModel>? OrderDetails { get; set; }

		
		public int CategoryId { get; set; }
		public CategoryViewModel Category { get; set; }



	}
}
