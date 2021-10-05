using Sev1.Advertisements.Application.Repositories.Tag;
using Sev1.Advertisements.Domain;
using Sev1.Advertisements.Repository.Base;

namespace Sev1.Advertisements.Repository.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}