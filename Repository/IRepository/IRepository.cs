using MagicVilla.Model;
using System.Linq.Expressions;

namespace MagicVilla.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,string?includeproperties=null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeproperties = null);
        Task CreateAsync(T entity);
        Task SaveAsync();
        Task RemoveAsync(T entity);
        
    }
}
