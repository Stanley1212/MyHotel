using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHotel.Infrastructure
{
    public interface IServiceBase<TEntity>
    {
        Task<int> Insert(TEntity model);
        Task<int> Update(TEntity model);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
