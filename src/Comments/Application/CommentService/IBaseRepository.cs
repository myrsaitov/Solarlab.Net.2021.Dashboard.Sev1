using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken token);
        Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int PageSize, int PageNumber, CancellationToken token);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token);
        Task AddAsync(TEntity model, CancellationToken token);
        Task UpdateAsync(TEntity model, CancellationToken token);
        Task DeleteAsync(TEntity model, CancellationToken token);
        Task SaveChangesAsync(CancellationToken token);
    }
}
