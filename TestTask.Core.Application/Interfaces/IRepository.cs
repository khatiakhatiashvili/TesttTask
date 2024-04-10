using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Domain.Basics;

namespace TestTask.Core.Application.Interfaces
{
    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<Guid> CreateAsyncWithGuid(TEntity entity);
        Task<TEntity> ReadAsync(TKey id);      
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<int> UpdateAsync(TKey id, TEntity entity);
        Task<int> DeleteAsync(TKey id);      
         Task Update(TEntity entityToUpdate);  
        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);    

    }
}
