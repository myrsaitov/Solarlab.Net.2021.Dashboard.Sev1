using Microsoft.EntityFrameworkCore;
using Sev1.Accounts.AppServices.Services.User.Repositories;
using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.DataAccess.Repositories
{
    public sealed class UserRepository : EfRepository<User, string>, IUserRepository
    {
        public UserRepository(DatabaseContext dbСontext) : base(dbСontext)
        {
        }
        public async Task<User> FindByUserName(
            string userName, 
            CancellationToken cancellationToken)
        {
            return await DbСontext
                .Set<User>()
                .FirstOrDefaultAsync(a => a.UserName == userName, cancellationToken);
        }
    }
}