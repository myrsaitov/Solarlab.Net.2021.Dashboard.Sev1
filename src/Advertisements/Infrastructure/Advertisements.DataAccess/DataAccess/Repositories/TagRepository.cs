using Sev1.Advertisements.Application.Repositories.Tag;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}