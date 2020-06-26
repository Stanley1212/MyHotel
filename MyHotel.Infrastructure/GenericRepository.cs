using MyHotel.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Infrastructure
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _applicationDbContext;
        protected DbSet<TEntity> _DbSet;
        private bool disposed = false;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this._DbSet = applicationDbContext.Set<TEntity>();
        }

        public async Task<int> Insert(TEntity entity)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().Add(entity);
                var result= await _applicationDbContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(List<TEntity> entityList)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().AddRange(entityList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Update(TEntity entity)
        {
            try
            {
                _DbSet.Attach(entity);
                _applicationDbContext.Entry(entity).State = EntityState.Modified;

                return await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TEntity GetById(int id)
        {
            var query = _applicationDbContext.Set<TEntity>().Find(id);
            return query;
        }
        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {

                var query = _applicationDbContext.Set<TEntity>().ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
        params object[] parameters)
        {
            return _DbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<int> Save()
        {
          return  await _applicationDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
