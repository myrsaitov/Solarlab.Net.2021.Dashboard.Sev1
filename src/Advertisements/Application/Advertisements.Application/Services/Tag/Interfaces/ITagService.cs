using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.Tag.Responses;

namespace Sev1.Advertisements.AppServices.Services.Tag.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Возвращает Tags с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<TagGetPagedResponse> GetPaged(
            GetPagedRequest request,
            CancellationToken cancellationToken);
    }
}