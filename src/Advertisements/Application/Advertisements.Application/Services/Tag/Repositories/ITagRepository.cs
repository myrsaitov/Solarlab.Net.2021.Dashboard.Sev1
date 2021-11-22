using Sev1.Advertisements.Domain.Base.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.AppServices.Services.Tag.Repositories
{
    /// <summary>
    /// Репозиторий Tag
    /// </summary>
    public interface ITagRepository : IRepository<Domain.Tag, int?>
    {
        /// <summary>
        /// Возвращает таги с пагинацией
        /// </summary>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Domain.Tag>> GetPagedWhereAdvertismentsNotNull(
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}