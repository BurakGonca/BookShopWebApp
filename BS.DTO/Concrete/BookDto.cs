﻿using BS.DTO.Abstract;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class BookDto : BaseDto
	{
		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }


		public DateTime? PublishDate { get; set; }
		public double Price { get; set; }
		public int StockQuantity { get; set; }
		public string? ImageName { get; set; }



		//iliskiler

		public IEnumerable<CommentDto>? Comments { get; set; }
		public IEnumerable<OrderDetailDto>? OrderDetails { get; set; }
		public IEnumerable<ShoppingCartBookDto> ShoppingCartBooks { get; set; }

		public int CategoryId { get; set; }
		public CategoryDto? Category { get; set; }



	}
}
