﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Repositories.Base;

namespace Sev1.Advertisements.Application.Repositories.Advertisement
{
    /// <summary>
    /// Репозиторий объявлений
    /// </summary>
    public interface IAdvertisementRepository : IRepository<Domain.Advertisement, int>
    {
        /// <summary>
        /// Возвращает объявление
        /// с прикрепленным автором этого объявления и связанными Tags
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<Domain.Advertisement> FindByIdWithTagsInclude(
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
        Task<Domain.Advertisement> FindByIdWithCategoriesAndTags(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает количество объявлений,
        /// которые не "удалены" с фильтром
        /// </summary>
        /// <param name="predicate">Параметры фильтра</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> CountActive(
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
        Task<IEnumerable<Domain.Advertisement>> GetPagedWithTagsAndCategoryInclude(
            Expression<Func<Domain.Advertisement, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}