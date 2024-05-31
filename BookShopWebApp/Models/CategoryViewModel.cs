namespace BookShopWebApp.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }



		//iliskiler

		public IEnumerable<BookViewModel>? Books { get; set; }



		//yardimcilar
		public int RowNum { get; set; }


        public int CurrentPage { get; set; } // Şu anki sayfa numarası
        public int TotalPages { get; set; } // Toplam sayfa sayısı

    }
}
