using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.Infrastructure.DataAccess.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}