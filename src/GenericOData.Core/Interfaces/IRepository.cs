using Microsoft.AspNetCore.OData.Deltas;

namespace GenericOData.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> PatchAsync(int key, Delta<T> entity);
        Task<T> UpdateAsync(int key, T entity);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int key);
    }
}