using AutoMapper;
using BS.DAL.Services.Abstract;
using BS.DTO.Abstract;
using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BS.BLL.Managers.Abstract
{
	public abstract class Manager<TDto, TEntity> : IManager<TDto> where TEntity : BaseEntity where TDto : BaseDto
	{

		protected Service<TEntity, TDto> _service;

		protected Manager(Service<TEntity, TDto> service)
		{
			_service = service;
		}

		public int Create(TDto dto) { return _service.Create(dto); }
		

		public int Delete(TDto dto) { return _service.Delete(dto); }


		public virtual IEnumerable<TDto> GetAll() { return _service.GetAll(); }


		public TDto? GetById(int id) { return _service.GetById(id); }

		

		public int Update(TDto dto) { return _service.Update(dto); }


		public IEnumerable<TDto> Search(Expression<Func<TDto, bool>> predicate) { return _service.Search(predicate); }
		

	}
}
