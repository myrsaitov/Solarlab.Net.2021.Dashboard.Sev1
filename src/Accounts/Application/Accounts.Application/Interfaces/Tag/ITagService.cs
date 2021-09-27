using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.GetPaged;
using Sev1.Accounts.Application.Contracts.Tag;

namespace Sev1.Accounts.Application.Interfaces.Tag
{
    public interface ITagService
    {
        /// <summary>
        /// Возвращает Tags с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedResponse<TagPagedDto>> GetPaged(
            GetPagedRequest request,
            CancellationToken cancellationToken);
    }
}