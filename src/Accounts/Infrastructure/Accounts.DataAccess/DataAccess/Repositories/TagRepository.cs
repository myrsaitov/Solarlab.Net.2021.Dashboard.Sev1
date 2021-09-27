using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.DataAccess.Interfaces;
using Sev1.Accounts.Domain;

namespace Sev1.Accounts.DataAccess.Repositories
{
    public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}