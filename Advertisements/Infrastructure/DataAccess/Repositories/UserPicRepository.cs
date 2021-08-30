using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.Infrastructure.DataAccess.Repositories
{
    public sealed class UserPicRepository : EfRepository<UserPic, int>, IUserPicRepository
    {
        public UserPicRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}