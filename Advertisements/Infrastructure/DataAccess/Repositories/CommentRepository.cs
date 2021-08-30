using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Sev1.Advertisements.Infrastructure.DataAccess.Repositories
{
    public sealed class CommentRepository : EfRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }

        public async Task<Comment> FindByIdWithUserInclude(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Comment>()
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<Comment> FindByIdWithUserAndCommentsInclude(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Comment>()
                .Include(a => a.Owner)
                .Include(a => a.ParentComment)
                .Include(a => a.ChildComments)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Comment>> GetPagedWithOwnerAndCommentInclude(
            Expression<Func<Comment, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Comment>()
                .Include(a => a.Owner)
                .Include(a => a.ParentComment)
                .Include(a => a.ChildComments)
                .AsNoTracking(); ;

            return await data
                .Where(predicate)
                .OrderByDescending(e => e.CreatedAt)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
    }
}