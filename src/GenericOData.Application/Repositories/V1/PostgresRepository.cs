using GenericOData.Application.DbContexts.V1;
using GenericOData.Core.Interfaces;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Repositories.V1
{
    public class PostgresRepository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext _context;

        public PostgresRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = (await _context.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<T> PatchAsync(int key, Delta<T> entity)
        {
            var changedProperties = entity.GetChangedPropertyNames();
            if (changedProperties == null)
            {
                return null;
            }

            T entityToPatch = await _context.Set<T>().FindAsync(key);

            if (entityToPatch == null)
            {
                return null;
            }

            entity.Patch(entityToPatch);
            await _context.SaveChangesAsync();

            var foundEntity = await _context.Set<T>().FindAsync(key);
            return foundEntity;
        }

        public async Task<T> UpdateAsync(int key, T entity)
        {
            if (entity == null)
            {
                return null;
            }

            T existing = await _context.Set<T>().FindAsync(key);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return existing;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var existing = await _context.Set<T>().FindAsync(id);
            return existing;
        }

        public async Task DeleteAsync(int key)
        {
            T existing = await _context.Set<T>().FindAsync(key);

            if (existing != null)
            {
                _context.Set<T>().Remove(existing);

                await _context.SaveChangesAsync();
            }
        }
    }
}
