using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Account;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.Application.Validators.Account;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        public async Task Delete(
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

            var account = await _accountRepository.FindByIdWithUserAndTagsInclude(
                id,
                cancellationToken);

            if (account == null)
            {
                throw new AccountNotFoundException(id);
            }

            account.IsDeleted = true;
            account.UpdatedAt = DateTime.UtcNow;



            await _accountRepository.Save(account, cancellationToken);
        }
    }
}