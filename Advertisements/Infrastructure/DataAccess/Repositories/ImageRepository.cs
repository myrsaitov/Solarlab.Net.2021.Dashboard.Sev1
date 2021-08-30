using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.Infrastructure.DataAccess.Repositories
{
    public sealed class ImageRepository : EfRepository<Image, int>, IImageRepository
    {
        public ImageRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}