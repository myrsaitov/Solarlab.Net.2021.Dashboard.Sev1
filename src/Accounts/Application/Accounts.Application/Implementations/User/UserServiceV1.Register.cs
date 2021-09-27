using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Application.Exceptions.User;
using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Application.Validators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        public async Task<Register.Response> Register(
            Register.Request registerRequest, 
            CancellationToken cancellationToken)
        {
            RegisterRequestValidator validator = new();
            var result = await validator.ValidateAsync(registerRequest);

            if (!result.IsValid)
            {
                throw new UserRegisteredException(string.Join(';', result.Errors.Select(x => x.ErrorMessage)));
            }

            CreateUser.Response response = await _identityService.CreateUser(
                _mapper.Map<CreateUser.Request>(registerRequest),
                cancellationToken);

            if (response.IsSuccess)
            {
                var domainUser = new Domain.User
                {
                    Id = response.UserId,
                    UserName = registerRequest.UserName,
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    MiddleName = registerRequest.MiddleName,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.Save(domainUser, cancellationToken);

                return _mapper.Map<Register.Response>(response);
            }

            throw new UserRegisteredException(string.Join(';', response.Errors));
        }
    }
}