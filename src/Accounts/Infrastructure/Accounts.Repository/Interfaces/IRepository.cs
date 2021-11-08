using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Repository.Interfaces
{
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
    {
        Task<TEntity> FindById(
            TId id, 
            CancellationToken cancellationToken);
        Task Save(
            TEntity entity, 
            CancellationToken cancellationToken);
        Task<TEntity> FindWhere(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken);
        Task<int> Count(CancellationToken cancellationToken);
        Task<int> Count(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetPaged(
            int offset, 
            int limit, 
            CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetPaged(
            Expression<Func<TEntity, bool>> predicate,
            int offset, 
            int limit,
            CancellationToken cancellationToken);
    }
}