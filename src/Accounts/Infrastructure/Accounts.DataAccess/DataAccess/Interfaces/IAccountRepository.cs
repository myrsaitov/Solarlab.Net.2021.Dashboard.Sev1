using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.DataAccess.Base;
using Sev1.Accounts.Domain;

namespace Sev1.Accounts.DataAccess.Interfaces
{
    /// <summary>
    /// Репозиторий объявлений
    /// </summary>
    public interface IAccountRepository : IRepository<Account, int>
    {
        /// <summary>
        /// Возвращает объявление
        /// с прикрепленным автором этого объявления
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Account> FindByIdWithUserInclude(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявление
        /// с прикрепленным автором этого объявления и связанными Tags
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Account> FindByIdWithUserAndTagsInclude(
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявление
        /// с прикрепленным автором этого объявления,
        /// категорией и связанными Tags
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Account> FindByIdWithUserAndCategoryAndTags(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество объявлений,
        /// которые не "удалены"
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> CountWithOutDeleted(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество объявлений,
        /// которые не "удалены" с фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> CountWithOutDeleted(
            Expression<Func<Account, bool>> predicate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией
        /// </summary>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Account>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            int offset,
            int limit,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией и фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="offset">Сколько объявлений пропущено</param>
        /// <param name="limit">Количество объявлений на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Account>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            Expression<Func<Account, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}