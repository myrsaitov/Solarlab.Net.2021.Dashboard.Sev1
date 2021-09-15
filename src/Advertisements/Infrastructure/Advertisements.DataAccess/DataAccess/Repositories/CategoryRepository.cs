using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.DataAccess.Interfaces;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class CategoryRepository : EfRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
        public async Task<Category> FindByIdWithParentAndChilds(
            int id, 
            CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<Category>()
                .Include(a => a.ChildCategories)
                .Include(a => a.ParentCategory)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
    }
}