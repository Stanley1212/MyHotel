using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> Insert(TEntity entity);
        Task<int> Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetWithRawSql(string query,
       params object[] parameters);

        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<int> Save();
        void Dispose();
    }
}
