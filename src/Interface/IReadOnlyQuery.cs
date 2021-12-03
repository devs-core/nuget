using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andreani.ARQ.Core.Interface
{
    public interface IReadOnlyQuery
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(string table) where T : class;
        Task<T> GetByIdAsync<T>(object id) where T : class;
        Task<T> GetByIdAsync<T>(string columnId, object id) where T : class;
        Task<IEnumerable<T>> GetAsync<T>(string table, string column, string parameter) where T : class;
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object param = null) where T : class;
        Task<T> FirstOrDefaultQueryAsync<T>(string sql, object param = null) where T : class;
    }
}
