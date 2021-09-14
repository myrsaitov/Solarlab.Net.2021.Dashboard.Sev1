using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Contracts;

namespace Sev1.Advertisements.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<int> Create(
            CategoryCreateDto request, 
            CancellationToken cancellationToken);

        Task<int> Update(
            CategoryUpdateDto request, 
            CancellationToken cancellationToken);

        Task Delete(
            int id, 
            CancellationToken cancellationToken);

        Task Restore(
            int id, 
            CancellationToken cancellationToken);

        Task<CategoryDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        Task<Paged.Response<CategoryDto>> GetPaged(
            Paged.Request request, 
            CancellationToken cancellationToken);
    }
}