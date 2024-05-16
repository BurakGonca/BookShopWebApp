namespace BookShopWebApp.Models
{
	public class BookViewModel
	{

		public int Id { get; set; }

		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }


		public DateTime? PublishDate { get; set; }
		public double Price { get; set; }
		public int StockQuantity { get; set; }
		public string? ImageName { get; set; }

		public IFormFile? ImageFile { get; set; }

		
		//iliskiler

		public IQueryable<CommentViewModel>? Comments { get; set; }
		public IQueryable<OrderDetailViewModel>? OrderDetails { get; set; }


		public int CategoryId { get; set; }
		public CategoryViewModel Category { get; set; }


		public int RowNum { get; set; }

	}
}
