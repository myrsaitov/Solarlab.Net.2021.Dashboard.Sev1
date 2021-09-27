using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Account;
using Sev1.Accounts.Application.Exceptions.Account;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.Application.Validators.Account;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        public async Task<AccountDto> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AccountIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new AccountIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var account = await _accountRepository.FindByIdWithUserAndCategoryAndTags(
                id,
                cancellationToken);

            if (account == null)
            {
                throw new AccountNotFoundException(id);
            }

            var response = _mapper.Map<AccountDto>(account);

            return response;
        }
    }
}