using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Domain.Basics;
using XAct;
using XAct.Domain.Repositories;

namespace TestTask.Infrastructure.Persistence.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<Guid, TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;
        public DbSet<TEntity> entities { get; set; }
        public Repository(DataContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        // create
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
             await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<Guid> CreateAsyncWithGuid(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public virtual async Task<TEntity> ReadAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }      
        public virtual async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<int> UpdateAsync(Guid id, TEntity entity)
        {
            var existing = entities.Find(id);
            _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var item = await this.ReadAsync(id);
            _context.Set<TEntity>().Remove(item);
            return await _context.SaveChangesAsync();
        }
     
        public virtual async Task Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentNullException("Update entityToUpdate is null");
            }

            entities.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;

           // _context.Set<TEntity>().Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }
      
    }
}
