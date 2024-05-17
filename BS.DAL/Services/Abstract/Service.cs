using AutoMapper;
using BS.DAL.Repositories.Abtract;
using BS.DAL.Repositories.Concrete;
using BS.DTO.Abstract;
using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Services.Abstract
{
	public abstract class Service<TEntity, TDto> : IService<TDto> where TDto : BaseDto where TEntity : BaseEntity
	{


		protected IMapper _mapper;
		public Repo<TEntity> _repo;

		public Service(Repo<TEntity> repo)
		{
			MapperConfiguration configuration = new MapperConfiguration(cfg => {
				cfg.CreateMap<TDto, TEntity>().ReverseMap();
			});


			_mapper = configuration.CreateMapper();
			_repo = repo;
		}

		//protected Service(BookRepo repo)
		//{
		//	this.repo = repo;
		//}

		public IMapper Mapper { set { _mapper = value; } }	


		public int Create(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto);
			return _repo.Create(entity);
		}

		public int Delete(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto);
			return _repo.Delete(entity);
		}

		public IEnumerable<TDto> GetAll()
		{
			IQueryable<TEntity> entities = _repo.GetAll();

            IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities);

			return dtos;
		}

		public TDto? GetById(int id)
		{
			TEntity? entity = _repo.GetById(id);
			TDto? dto = _mapper.Map<TDto>(entity);

			return dto;
		}

		public int Update(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto);
			return _repo.Update(entity);
		}


	}
}
