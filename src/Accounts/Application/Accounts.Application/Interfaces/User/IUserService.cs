using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Contracts.User.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Interfaces.User
{
    public interface IUserService
    {
        Task<string> Register(
            UserRegisterDto registerRequest, 
            CancellationToken cancellationToken);

        Task Update(
            UserUpdateRequest request, 
            CancellationToken cancellationToken);

        Task<Domain.User> Get(
            string userId,
            CancellationToken cancellationToken);
    }
}