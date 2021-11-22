using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;
using Sev1.Advertisements.DataAccess.Base;
using System.Collections.Generic;
using System.Linq;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class CategoryRepository : EfRepository<Category, int?>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
        public async Task<Category> FindByIdWithParentAndChilds(
            int? id, 
            CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Category>()
                .Include(a => a.ChildCategories)
                .Include(a => a.ParentCategory)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Category>> GetPagedWhithAdvertisments(
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Category>()
                .Include(a => a.Advertisements)
                .AsNoTracking();

            return await data
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
    }
}