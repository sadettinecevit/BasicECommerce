using BasicECommerce.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BasicECommerce.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(Guid id);
        Task<EntityEntry<T>> Add(T entity);
        Task<EntityEntry<T>> Update(T entity);
        Task<EntityEntry<T>> Delete(T entity);
    }
}
