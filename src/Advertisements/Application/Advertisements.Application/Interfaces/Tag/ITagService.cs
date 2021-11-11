using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Tag;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;

namespace Sev1.Advertisements.Application.Interfaces.Tag
{
    public interface ITagService
    {
        /// <summary>
        /// Возвращает Tags с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedTagDto> GetPaged(
            GetPagedRequest request,
            CancellationToken cancellationToken);
    }
}