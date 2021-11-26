using Sev1.Advertisements.AppServices.Services.Tag.Repositories;
using Sev1.Advertisements.Domain;
using Sev1.Advertisements.DataAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int?>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }

        public async Task<IEnumerable<Tag>> GetPagedWhereAdvertismentsNotNull(
            int offset,
            int limit,
            CancellationToken cancellationToken)
        {
            var data = DbСontext
                .Set<Tag>()
                .Include(a => a.Advertisements)
                .AsNoTracking();

            return await data
                .Where(t => t.Advertisements
                    .Where(a => a.Status == AdvertisementStatus.Active)
                    .Count() > 0)
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }
    }
}