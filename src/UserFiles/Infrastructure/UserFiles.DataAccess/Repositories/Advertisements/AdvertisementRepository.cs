using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Sev1.UserFiles.Application.Repositories.Advertisement;
using Sev1.UserFiles.DataAccess.Base;

namespace Sev1.UserFiles.DataAccess.Repositories
{
    public sealed class AdvertisementRepository : EfRepository<Advertisement, int>, IAdvertisementRepository
    {
        public AdvertisementRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }

        public async Task<Advertisement> FindByIdWithTagsInclude(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Advertisement>()
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<Advertisement> FindByIdWithCategoriesAndTags(int id, CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Advertisement>()
                .Include(a => a.Category)
                .Include(a => a.Category.ChildCategories)
                .Include(a => a.Category.ParentCategory)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<int> CountWithOutDeleted(CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Advertisement>()
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .CountAsync(cancellationToken);
        }
        public async Task<int> CountWithOutDeleted(
            Expression<Func<Advertisement, bool>> predicate,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Advertisement>()
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .Where(predicate)
                .CountAsync(cancellationToken);
        }
        public async Task<IEnumerable<Advertisement>> GetPagedWithTagsAndCategoryInclude(
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Advertisement>()
                .Include(a => a.Tags)
                .Include(a => a.Category)
                .AsNoTracking(); ;

            return await data
                .Where(c => c.IsDeleted == false)
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Advertisement>> GetPagedWithTagsAndCategoryInclude(
            Expression<Func<Advertisement, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Advertisement>()
                .Include(a => a.Tags)
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