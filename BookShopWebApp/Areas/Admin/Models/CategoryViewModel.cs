namespace BookShopWebApp.Areas.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }



		//iliskiler

		public IEnumerable<BookViewModel>? Books { get; set; }


		public int RowNum { get; set; }

	}
}
