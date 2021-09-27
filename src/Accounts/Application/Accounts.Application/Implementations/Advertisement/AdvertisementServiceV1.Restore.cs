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
        public async Task Restore(
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

            var advertisement = await _advertisementRepository.FindByIdWithUserInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AccountNotFoundException(id);
            }



            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}