using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Category.Contracts;
using Sev1.Advertisements.Application.Services.Category.Contracts.Exceptions;
using Sev1.Advertisements.Application.Services.Category.Interfaces;

namespace Sev1.Advertisements.Application.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<Update.Response> Update(
            Update.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var category = await _categoryRepository.FindById(
                request.Id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(request.Id);
            }


            category = _mapper.Map<Domain.Category>(request);

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            return new Update.Response
            {
                Id = category.Id
            };
        }
    }
}