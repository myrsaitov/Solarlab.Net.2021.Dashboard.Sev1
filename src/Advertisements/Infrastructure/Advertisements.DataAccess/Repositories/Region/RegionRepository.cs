using Sev1.Advertisements.Domain;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.AppServices.Services.Region.Repositories;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class RegionRepository : EfRepository<Region, int?>, IRegionRepository
    {
        public RegionRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}