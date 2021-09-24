using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.DomainUser;
using Sev1.Accounts.Application.Exceptions.DomainUser;
using Sev1.Accounts.Application.Exceptions.DomainUser;
using Sev1.Accounts.Application.Interfaces.DomainUser;
using Sev1.Accounts.Application.Validators.DomainUser;

namespace Sev1.Accounts.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        public async Task<int> Update(
            DomainUserUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new DomainUserUpdateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new DomainUserUpdateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var domainUser = await _domainUserRepository.FindById(
                model.Id, 
                cancellationToken);

            if (domainUser == null)
            {
                throw new DomainUserNotFoundException(model.Id);
            }


            domainUser = _mapper.Map<Domain.DomainUser>(model);

            domainUser.IsDeleted = false;
            domainUser.UpdatedAt = DateTime.UtcNow;
            await _domainUserRepository.Save(domainUser, cancellationToken);

            return domainUser.Id;
        }
    }
}