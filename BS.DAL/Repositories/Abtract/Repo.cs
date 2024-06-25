using BS.DAL.Context;
using BS.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Repositories.Abtract
{
	public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
	{

		protected BSDbContext _dbContext;

		protected DbSet<TEntity> entities;

		protected Repo(BSDbContext dbContext)
		{
			_dbContext = dbContext;

			entities = _dbContext.Set<TEntity>();

			_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
		}

		public int Create(TEntity entity)
		{
			entity.CreatedDate = DateTime.Now;
			entities.Add(entity);
			return _dbContext.SaveChanges();


		}

		public int Delete(TEntity entity)
		{
			entities.Remove(entity);
			return _dbContext.SaveChanges();
		}

		public virtual IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
		}	

		public virtual TEntity? GetById(int id)
		{
			return entities.SingleOrDefault(e => e.Id == id);
		}

		

		public int Update(TEntity entity)
		{
			
			TEntity entity1 = GetById(entity.Id);

			entity.CreatedDate = entity1.CreatedDate;
			entity.UpdatedDate = DateTime.Now;

			entities.Update(entity);

			return _dbContext.SaveChanges();


		}


		//filtre ederek getirecek
		public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
		{
			var allEntities = GetAll();

			

            return allEntities.Where(predicate);

		}





	}
}
