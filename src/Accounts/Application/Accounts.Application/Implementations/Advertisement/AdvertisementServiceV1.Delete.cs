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

            var advertisement = await _advertisementRepository.FindByIdWithUserAndTagsInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AccountNotFoundException(id);
            }

            advertisement.IsDeleted = true;
            advertisement.UpdatedAt = DateTime.UtcNow;

            // TODO Сделать нормальный подсчет количества Tags
            foreach (var tag in advertisement.Tags)
            {
                if (tag.Count > 0)
                {
                    tag.Count -= 1;
                    await _tagRepository.Save(tag, cancellationToken);
                }
            }

            await _advertisementRepository.Save(advertisement, cancellationToken);
        }
    }
}