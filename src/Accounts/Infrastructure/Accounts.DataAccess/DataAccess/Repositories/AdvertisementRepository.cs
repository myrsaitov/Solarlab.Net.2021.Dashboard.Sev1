using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.DataAccess.Interfaces;

namespace Sev1.Accounts.DataAccess.Repositories
{
    public sealed class AccountRepository : EfRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }

        public async Task<Account> FindByIdWithUserInclude(
            int id, 
            CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Account>()
                //.Include(a => a.Owner)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<Account> FindByIdWithUserAndTagsInclude(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Account>()
                //.Include(a => a.Owner)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<Account> FindByIdWithUserAndCategoryAndTags(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Account>()
                //.Include(a => a.Owner)
                .Include(a => a.Category)
                .Include(a => a.Category.ChildCategories)
                .Include(a => a.Category.ParentCategory)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<int> CountWithOutDeleted(CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Account>()
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .CountAsync(cancellationToken);
        }
        public async Task<int> CountWithOutDeleted(
            Expression<Func<Account, bool>> predicate,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Account>()
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .Where(predicate)
                .CountAsync(cancellationToken);
        }
        public async Task<IEnumerable<Account>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Account>()
                .Include(a => a.Tags)
                //.Include(a => a.Owner)
                .Include(a => a.Category)
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Account>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            Expression<Func<Account, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Account>()
                .Include(a => a.Tags)
                //.Include(a => a.Owner)
                .Include(a => a.Category)
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