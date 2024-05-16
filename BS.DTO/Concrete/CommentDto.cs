using BS.DTO.Abstract;
using BS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class CommentDto : BaseDto
	{
		public string? CommentTitle { get; set; }
		public string? CommentContent { get; set; }
		public Rating Rating { get; set; }
		public DateTime CommentDate { get; set; }



		//iliskiler

		public int UserId { get; set; }
		public UserDto User { get; set; }


		public int BookId { get; set; }
		public BookDto Book { get; set; }

	}
}
