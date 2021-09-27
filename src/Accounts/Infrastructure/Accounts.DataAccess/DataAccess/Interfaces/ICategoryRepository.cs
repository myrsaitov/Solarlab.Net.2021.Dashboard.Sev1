using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.Domain;

namespace Sev1.Accounts.DataAccess.Interfaces
{
    /// <summary>
    /// Репозиторий категорий
    /// </summary>
    public interface ICategoryRepository : IRepository<Category, int>
    {
        /// <summary>
        /// Возвращает категорию вместе с прикрепленными
        /// родительской и подкатегориями
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public Task<Category> FindByIdWithParentAndChilds(int id, CancellationToken cancellationToken);
    }
}