using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Domain.Base.Entities;

namespace Sev1.UserFiles.Domain.Base.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="TEntity">Класс сущности</typeparam>
    /// <typeparam name="TId">Класс идентификатора сущности</typeparam>
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
    {
        /// <summary>
        /// Возвращает сущность по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<TEntity> FindById(
            TId id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Сохраняет сущность
        /// </summary>
        /// <param name="entity">Модель сущности</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Save(
            TEntity entity, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Поиск с фильтром
        /// </summary>
        /// <param name="predicate">Условие фильтра</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<TEntity> FindWhere(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество сущностей
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int?> Count(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество сущностей с фильтром
        /// </summary>
        /// <param name="predicate">Условие фильтра</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int?> Count(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает сущности с пагинацией
        /// </summary>
        /// <param name="offset">Смещение</param>
        /// <param name="limit">Количество на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetPaged(
            int offset, 
            int limit, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает сущности с пагинацией и фильтрацией
        /// </summary>
        /// <param name="predicate">Условие фильтра</param>
        /// <param name="offset">Смещение</param>
        /// <param name="limit">Количество на странице</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetPaged(
            Expression<Func<TEntity, bool>> predicate,
            int offset, 
            int limit,
            CancellationToken cancellationToken);
    }
}