using BS.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
	public class CategoryDto : BaseDto
	{
		public string CategoryName { get; set; }



		//iliskiler

		public IEnumerable<BookDto> Books { get; set; }



	}
}
