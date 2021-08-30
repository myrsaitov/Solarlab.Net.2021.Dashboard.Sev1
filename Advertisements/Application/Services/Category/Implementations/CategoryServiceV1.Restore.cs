using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Common;
using Sev1.Advertisements.Application.Services.Category.Contracts;
using Sev1.Advertisements.Application.Services.Category.Contracts.Exceptions;
using Sev1.Advertisements.Application.Services.Category.Interfaces;
using Sev1.Advertisements.Domain.Shared.Exceptions;

namespace Sev1.Advertisements.Application.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        public async Task Restore(
            Restore.Request request,
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

            var userId = await _identityService.GetCurrentUserId(cancellationToken);
            
            var isAdmin = await _identityService.IsInRole(
                userId, 
                RoleConstants.AdminRole, 
                cancellationToken);

            if (!isAdmin)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
            }

            category.IsDeleted = false;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(
                category, 
                cancellationToken);
        }
    }
}