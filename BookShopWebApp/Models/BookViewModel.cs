using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models
{
	public class BookViewModel
	{

		public int Id { get; set; }

		[Display(Name = "Kitap Adı")]
		public string BookName { get; set; }
		[Display(Name = "Yazar Adı")]
		public string AuthorName { get; set; }
		[Display(Name = "Yazar Soyadı")]
		public string AuthorSurname { get; set; }

		[Display(Name = "Yayın Yılı")]
		public DateTime? PublishDate { get; set; } = DateTime.Now;
		[Display(Name = "Fiyatı")]
		public double Price { get; set; }
		[Display(Name = "Stok Adeti")]
		public int StockQuantity { get; set; }
		public string? ImageName { get; set; }

		[Display(Name = "Kapak Resmi")]
		public IFormFile? ImageFile { get; set; }

		
		//iliskiler

		public IEnumerable<CommentViewModel>? Comments { get; set; }
		public IEnumerable<OrderDetailViewModel>? OrderDetails { get; set; }

		[Display(Name = "Kategorisi")]
		public int CategoryId { get; set; }
		public CategoryViewModel Category { get; set; }

			

		public int RowNum { get; set; }

	}
}
