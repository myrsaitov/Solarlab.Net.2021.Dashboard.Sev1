using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain.Base.Repositories;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Repositories
{
    /// <summary>
    /// Репозиторий объявлений
    /// </summary>
    public interface IAdvertisementRepository : IRepository<Domain.Advertisement, int?>
    {
        /// <summary>
        /// Возвращает объявление по идентификатору
        /// с прикрепленным автором этого объявления и связанными Tags
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Domain.Advertisement> FindByIdWithTagsInclude(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявление по идентификатору
        /// с прикрепленным автором этого объявления,
        /// категорией и связанными Tags
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Domain.Advertisement> FindByIdWithCategoriesAndTagsAndUserFiles(
            int? id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество объявлений,
        /// которые не "удалены" с фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int?> CountActive(
            Expression<Func<Domain.Advertisement, bool>> predicate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией и фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Domain.Advertisement>> GetPagedWithTagsAndCategoryAndUserFilesInclude(
            Expression<Func<Domain.Advertisement, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}