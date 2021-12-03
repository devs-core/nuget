using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andreani.ARQ.Core.Interface
{
    public interface ITransactionalRepository
    {
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        Task SaveChangeAsync();
        void SaveChange();
    }
}
