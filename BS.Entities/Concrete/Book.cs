using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class Book : BaseEntity, IBook
	{

		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }


		public DateTime? PublishDate { get; set; }
		public double Price { get; set; }
		public int StockQuantity { get; set; }
		public string? ImageName { get; set; }



        //iliskiler

        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }


        public int CategoryId { get; set; }
        public Category? Category { get; set; }



        



    }
}
