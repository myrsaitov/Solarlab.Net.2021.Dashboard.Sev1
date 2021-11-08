using Sev1.Accounts.Application.Contracts.User;
using System.Threading;
using System.Threading.Tasks;


namespace Sev1.Accounts.Application.Interfaces.User
{
    public interface IUserService
    {
        Task<Register.Response> Register(
            Register.Request registerRequest, 
            CancellationToken cancellationToken);

        Task Update(
            Update.Request request, 
            CancellationToken cancellationToken);

        Task<Domain.User> Get(
            string userId,
            CancellationToken cancellationToken);
    }
}