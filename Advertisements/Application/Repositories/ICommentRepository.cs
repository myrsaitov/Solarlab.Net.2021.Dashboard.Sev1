using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.Application.Repositories
{
    public interface ICommentRepository : IRepository<Domain.Comment, int>
    {
        Task<Domain.Comment> FindByIdWithUserInclude(
            int id, 
            CancellationToken cancellationToken);
        Task<Domain.Comment> FindByIdWithUserAndCommentsInclude(
            int id, 
            CancellationToken cancellationToken);
        Task<IEnumerable<Comment>> GetPagedWithOwnerAndCommentInclude(
            Expression<Func<Comment, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}