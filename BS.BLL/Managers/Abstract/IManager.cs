using BS.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BLL.Managers.Abstract
{
	public interface IManager<TDto> where TDto : BaseDto
	{

		int Create(TDto dto);
		int Update(TDto dto);
		int Delete(TDto dto);
		IEnumerable<TDto> GetAll();
		TDto? GetById(int id);

	}
}
