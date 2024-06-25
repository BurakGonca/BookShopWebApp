using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Repositories.Abtract
{
	public interface IRepo<TEntity> where TEntity : BaseEntity
	{

		int Create(TEntity entity);
		int Update(TEntity entity);
		int Delete(TEntity entity);

		TEntity GetById(int id);
		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);



	}
}
