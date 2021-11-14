using Sev1.Advertisements.Application.Services.Repositories.Tag;
using Sev1.Advertisements.Domain;
using Sev1.Advertisements.DataAccess.Base;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class RegionRepository : EfRepository<Region, int?>, IRegionRepository
    {
        public RegionRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}