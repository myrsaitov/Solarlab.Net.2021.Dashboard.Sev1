using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Domain.Base.Repositories;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Repositories
{
    /// <summary>
    /// Репозиторий объявлений
    /// </summary>
    public interface IUserFileRepository : IRepository<Domain.UserFile, int?>
    {
        /// <summary>
        /// Возвращает количество объявлений,
        /// которые не "удалены" с фильтром
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int?> CountWithOutDeleted(
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией и фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Domain.UserFile>> GetPagedWithTagsAndCategoryInclude(
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}