namespace BookShopWebApp.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }



		//iliskiler

		public IQueryable<BookViewModel> Books { get; set; }


		public int RowNum { get; set; }

	}
}
