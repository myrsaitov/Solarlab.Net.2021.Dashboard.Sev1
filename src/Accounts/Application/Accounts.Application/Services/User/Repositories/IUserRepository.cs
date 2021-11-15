using Sev1.Accounts.Domain.Base.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.AppServices.Services.User.Repositories
{
    public interface IUserRepository : IRepository<Domain.User, string>
    {
        Task<Domain.User> FindByUserName(
            string userName,
            CancellationToken cancellationToken);
    }
}