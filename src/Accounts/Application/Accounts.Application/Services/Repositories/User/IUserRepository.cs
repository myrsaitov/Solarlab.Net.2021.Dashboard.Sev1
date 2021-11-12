using Sev1.Accounts.Application.Services.Repository.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Services.Repository.User
{
    public interface IUserRepository : IRepository<Domain.User, string>
    {
        Task<Domain.User> FindByUserName(
            string userName,
            CancellationToken cancellationToken);
    }
}