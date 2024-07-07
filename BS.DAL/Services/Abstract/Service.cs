using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BS.DAL.Repositories.Abtract;
using BS.DAL.Repositories.Concrete;
using BS.DTO.Abstract;
using BS.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
				cfg.AddExpressionMapping().CreateMap<TDto, TEntity>().ReverseMap();
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
			TEntity entity = _mapper.Map<TEntity>(dto); //mapledikten sonra ıd yi sıfırladı
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


		public List<TDto> Search(Expression<Func<TDto, bool>> predicate)
		{
			Expression<Func<TEntity, bool>> predicateEntities = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            List<TEntity> entities = _repo.Search(predicateEntities).ToList();

			var c = _repo.Search(predicateEntities).ToList(); 

            List<TDto> dtos = _mapper.Map<List<TDto>>(entities);

			return dtos;

		}




	}
}
