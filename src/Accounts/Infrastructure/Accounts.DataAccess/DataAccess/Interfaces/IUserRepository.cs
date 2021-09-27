using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<User> FindByUserName(
            string userName,
            CancellationToken cancellationToken);
    }
}