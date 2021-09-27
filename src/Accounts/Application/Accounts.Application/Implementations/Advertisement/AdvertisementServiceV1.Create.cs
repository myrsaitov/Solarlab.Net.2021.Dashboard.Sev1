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

            var category = await _categoryRepository.FindById(
                model.CategoryId,
                cancellationToken);

            if (category is null)
            {
                throw new CategoryNotFoundException(model.CategoryId);
            }

            var advertisement = _mapper.Map<Domain.Account>(model);
            advertisement.IsDeleted = false;
            advertisement.CreatedAt = DateTime.UtcNow;
            advertisement.Category = category;

            if (model.TagBodies is not null)
            {
                advertisement.Tags = new List<Domain.Tag>();
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

                        advertisement.Tags.Add(tag);
                    }
                }
            }

            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}