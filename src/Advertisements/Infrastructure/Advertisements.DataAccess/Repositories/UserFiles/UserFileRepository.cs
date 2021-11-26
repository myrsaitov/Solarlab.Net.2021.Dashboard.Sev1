using Sev1.Advertisements.Domain;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;

namespace Sev1.Advertisements.DataAccess.Repositories
{
    public sealed class UserFileRepository : EfRepository<UserFile, int?>, IUserFileRepository
    {
        public UserFileRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
    }
}