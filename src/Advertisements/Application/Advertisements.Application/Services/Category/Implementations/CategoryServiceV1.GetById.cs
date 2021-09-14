using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Application.Services.Category.Interfaces;

namespace Sev1.Advertisements.Application.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task<GetById.Response> GetById(
            GetById.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var category = await _categoryRepository.FindByIdWithParentAndChilds(
                request.Id, 
                cancellationToken);

            if (category == null)
            {
                throw new CategoryNotFoundException(request.Id);
            }

            return _mapper.Map<GetById.Response>(category);
        }
    }
}