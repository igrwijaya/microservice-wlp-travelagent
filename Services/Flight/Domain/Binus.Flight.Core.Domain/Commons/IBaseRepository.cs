using System.Collections.Generic;
using System.Threading.Tasks;

namespace Binus.Flight.Core.Domain.Commons
{
    public interface IBaseRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        #region Public Methods

        Task<int> CreateAsync(TEntity entity);

        Task<TEntity> ReadAsync(int id);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task<bool> IsExist(int id);

        IEnumerable<TEntity> GetAll();
 
        CoreDataTable<TEntity> GetDataTable(int page, int size);

        IEnumerable<TEntity> Get(int page, int size);

        #endregion
    }
}