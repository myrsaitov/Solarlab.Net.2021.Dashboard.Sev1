using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Exceptions.Account;
using Sev1.Accounts.Application.Contracts.Account;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.Application.Contracts.Tag;
using Sev1.Accounts.Application.Validators.Account;
using System.Linq;
using Sev1.Accounts.Application.Exceptions.Category;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        public async Task<int> Update(
            AccountUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new AccountUpdateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new AccountUpdateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var account = await _accountRepository.FindByIdWithUserAndCategoryAndTags(
                model.Id,
                cancellationToken);

            if (account == null)
            {
                throw new AccountNotFoundException(model.Id);
            }

            // TODO Mapper
            account.Title = model.Title;
            account.Body = model.Body;
            account.Price = model.Price;
            account.CategoryId = model.CategoryId;

            account.IsDeleted = false;
            account.UpdatedAt = DateTime.UtcNow;

            var category = await _categoryRepository.FindById(
                account.CategoryId,
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(account.CategoryId);
            }

            account.Category = category;
            if (account.Tags == null)
            {
                account.Tags = new List<Domain.Tag>();
            }
            account.Tags.Clear();

            if (model.TagBodies is not null)
            {
                foreach (string body in model.TagBodies)
                {
                    if (body.Length > 0)
                    {
                        var tag = await _tagRepository.FindWhere(
                        a => a.Body == body,
                        cancellationToken);

                        if (tag == null)
                        {
                            var tagRequest = new TagCreateDto()
                            {
                                Body = body
                            };

                            tag = _mapper.Map<Domain.Tag>(tagRequest);
                            tag.CreatedAt = DateTime.UtcNow;
                            tag.Count = 1;

                            await _tagRepository.Save(
                                tag,
                                cancellationToken);
                        }
                        else
                        {
                            // TODO Переделать с поиском в базе, учесть удаленные объявления
                            tag.Count += 1;
                            await _tagRepository.Save(tag, cancellationToken);
                        }

                        account.Tags.Add(tag);
                    }
                }
            }

            await _accountRepository.Save(
                account, 
                cancellationToken);

            return account.Id;
        }
    }
}