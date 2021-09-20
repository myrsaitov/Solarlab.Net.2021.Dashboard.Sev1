using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.DomainUsers.Application.Exceptions.DomainUser;
using Sev1.DomainUsers.Application.Exceptions.DomainUser;
using Sev1.DomainUsers.Application.Interfaces.DomainUser;
using Sev1.DomainUsers.Application.Validators.DomainUser;

namespace Sev1.DomainUsers.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        public async Task Delete(
           int id,
           CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new DomainUserIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new DomainUserIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var domainUser = await _domainUserRepository.FindById(id, cancellationToken);
            if (domainUser == null)
            {
                throw new DomainUserNotFoundException(id);
            }

            domainUser.IsDeleted = true;
            domainUser.UpdatedAt = DateTime.UtcNow;
            await _domainUserRepository.Save(domainUser, cancellationToken);
        }
    }
}