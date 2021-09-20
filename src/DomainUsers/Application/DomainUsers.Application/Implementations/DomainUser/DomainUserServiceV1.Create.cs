using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.DomainUsers.Application.Contracts.DomainUser;
using System.Collections.Generic;
using Sev1.DomainUsers.Application.Interfaces.DomainUser;
using Sev1.DomainUsers.Application.Validators.DomainUser;
using Sev1.DomainUsers.Application.Exceptions.DomainUser;
using System.Linq;

namespace Sev1.DomainUsers.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        public async Task<int> Create(
            DomainUserCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new DomainUserCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new DomainUserCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var domainUser = _mapper.Map<Domain.DomainUser>(model);
            domainUser.IsDeleted = false;
            domainUser.CreatedAt = DateTime.UtcNow;
            await _domainUserRepository.Save(domainUser, cancellationToken);

            var parentDomainUserIdNulable = model.ParentDomainUserId;
            if (parentDomainUserIdNulable != null)
            {
                int parentDomainUserId = (int)parentDomainUserIdNulable;
                var parentDomainUser = await _domainUserRepository.FindById(parentDomainUserId, cancellationToken);
                if (parentDomainUser != null)
                {
                    if (parentDomainUser.ChildCategories != null)
                    {
                        parentDomainUser.ChildCategories.Add(domainUser);
                    }
                    else
                    {
                        parentDomainUser.ChildCategories = new List<Domain.DomainUser>()
                        {
                            domainUser
                        };
                    }
                    await _domainUserRepository.Save(parentDomainUser, cancellationToken);
                    
                    domainUser.ParentDomainUser = parentDomainUser;
                }
                await _domainUserRepository.Save(domainUser, cancellationToken);
            }

            return domainUser.Id;
        }
    }
}