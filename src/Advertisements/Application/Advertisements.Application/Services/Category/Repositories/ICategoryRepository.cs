using Sev1.Advertisements.Domain.Base.Repositories;
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
        public Task<Domain.Category> FindByIdWithParentAndChilds(int? id, CancellationToken cancellationToken);
    }
}