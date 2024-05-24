using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Areas.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }



		//iliskiler

		public IEnumerable<BookViewModel>? Books { get; set; }


		public int RowNum { get; set; }

		

	}
}
