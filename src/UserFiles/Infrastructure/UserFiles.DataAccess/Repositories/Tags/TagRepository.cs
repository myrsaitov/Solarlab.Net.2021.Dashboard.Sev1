using Sev1.UserFiles.Application.Repositories.Tag;
using Sev1.UserFiles.Domain;
using Sev1.UserFiles.DataAccess.Base;

namespace Sev1.UserFiles.DataAccess.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}