using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<CreateUser.Response> CreateUser(CreateUser.Request request, CancellationToken cancellationToken = default)
        {
            var existedUser = await _userManager.FindByNameAsync(request.UserName);
            if (existedUser != null)
            {
                throw new ConflictException("Пользователь с таким именем уже существует");
            }

            var identityUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var identityResult = await _userManager.CreateAsync(identityUser, request.Password);

            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, request.Role);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodedToken = HttpUtility.UrlEncode(token);
                var message = $"<a href=\"{_configuration["ApiUri"]}api/v1/users/confirm?userId={identityUser.Id}&token={encodedToken}\">Нажми меня</a>";

                //await _mailService.Send(request.Email, "Подтверди почту!", message, cancellationToken);

                return new CreateUser.Response
                {
                    UserId = identityUser.Id,
                    IsSuccess = true
                };
            }

            return new CreateUser.Response
            {
                IsSuccess = false,
                Errors = identityResult.Errors.Select(x => x.Description).ToArray()
            };
        }
    }
}
