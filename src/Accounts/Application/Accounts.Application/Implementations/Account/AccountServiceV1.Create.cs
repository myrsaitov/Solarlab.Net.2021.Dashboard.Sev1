using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Account;
using Sev1.Accounts.Application.Contracts.Account;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.Application.Validators.Account;
using System.Linq;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        public async Task Create(
            AccountCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AccountCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new AccountCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }



            var account = _mapper.Map<Domain.Account>(model);
            account.IsDeleted = false;
            account.CreatedAt = DateTime.UtcNow;

            await _accountRepository.Save(
                account, 
                cancellationToken);
        }
    }
}