using BasicECommerce.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BasicECommerce.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(string id);
        Task<EntityEntry<T>> Add(T entity);
        Task<EntityEntry<T>> Update(T entity);
        Task<EntityEntry<T>> Delete(T entity);
    }
}
