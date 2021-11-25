using Sev1.Advertisements.Domain.Base.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.AppServices.Services.Category.Repositories
{
    /// <summary>
    /// Репозиторий категорий
    /// </summary>
    public interface ICategoryRepository : IRepository<Domain.Category, int?>
    {
        /// <summary>
        /// Возвращает категорию вместе с прикрепленными
        /// родительской и подкатегориями
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public Task<Domain.Category> FindByIdWithParentAndChilds(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает категории с пагинацией
        /// </summary>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<ICollection<Domain.Category>> GetPagedWhithAdvertisments(
            int offset,
            int limit,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает все чайлды категории
        /// </summary>
        /// <param name="categoryId">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<ICollection<Domain.Category>> GetAllChilds(
            int? categoryId,
            CancellationToken cancellationToken);

    }
}