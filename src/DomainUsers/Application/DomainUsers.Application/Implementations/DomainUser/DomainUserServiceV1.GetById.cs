﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.DomainUsers.Application.Contracts.DomainUser;
using Sev1.DomainUsers.Application.Exceptions.DomainUser;
using Sev1.DomainUsers.Application.Exceptions.DomainUser;
using Sev1.DomainUsers.Application.Interfaces.DomainUser;
using Sev1.DomainUsers.Application.Validators.DomainUser;

namespace Sev1.DomainUsers.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        public async Task<DomainUserDto> GetById(
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

            var domainUser = await _domainUserRepository.FindByIdWithParentAndChilds(
                id, 
                cancellationToken);

            if (domainUser == null)
            {
                throw new DomainUserNotFoundException(id);
            }

            return _mapper.Map<DomainUserDto>(domainUser);
        }
    }
}