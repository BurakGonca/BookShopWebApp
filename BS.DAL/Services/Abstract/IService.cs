using BS.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Services.Abstract
{
	public interface IService<TDto> where TDto : BaseDto
	{

		int Create(TDto dto);
		int Update(TDto dto);
		int Delete(TDto dto);

		IQueryable<TDto> GetAll();

		TDto GetById(int id);


	}
}
