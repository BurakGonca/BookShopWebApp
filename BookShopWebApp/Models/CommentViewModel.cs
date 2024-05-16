using BS.Enums;

namespace BookShopWebApp.Models
{
	public class CommentViewModel
	{
		public int Id { get; set; }

		public string? CommentTitle { get; set; }
		public string? CommentContent { get; set; }
		public Rating Rating { get; set; }
		public DateTime CommentDate { get; set; }



		//iliskiler

		public int UserId { get; set; }
		public UserViewModel User { get; set; }


		public int BookId { get; set; }
		public BookViewModel Book { get; set; }


		public int RowNum { get; set; }

	}
}
