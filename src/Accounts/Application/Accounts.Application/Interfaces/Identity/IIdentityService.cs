using Sev1.Accounts.Application.Contracts.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<string> GetCurrentUserId(
            CancellationToken cancellationToken = default);

        Task<bool> IsInRole(
            string userId, 
            string role, 
            CancellationToken cancellationToken = default);

        Task<CreateUser.Response> CreateUser(
            CreateUser.Request request, 
            CancellationToken cancellationToken = default);

        Task<CreateToken.Response> CreateToken(
            CreateToken.Request request, 
            CancellationToken cancellationToken = default);

        Task<bool> ConfirmEmail(
            string userId, 
            string token, 
            CancellationToken cancellationToken = default);
    }
}
