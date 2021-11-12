using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Sev1.UserFiles.DataAccess.Base;
using Sev1.UserFiles.Application.Services.Repositories.UserFile;

namespace Sev1.UserFiles.DataAccess.Repositories
{
    public sealed class UserFileRepository : EfRepository<UserFile, int>, IUserFileRepository
    {
        public UserFileRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }

        public async Task<int> CountWithOutDeleted(
            Expression<Func<UserFile, bool>> predicate,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<UserFile>()
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .Where(predicate)
                .CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserFile>> GetPagedWithTagsAndCategoryInclude(
            Expression<Func<UserFile, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<UserFile>()
                .AsNoTracking();

            return await data
                .Where(c => c.IsDeleted == false)
                .Where(predicate)
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
    }
}