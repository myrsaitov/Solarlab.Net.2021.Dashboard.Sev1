using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.Category.Responses
{
    /// <summary>
    /// DTO ответа на запрос пагинации по категориям
    /// </summary>
    public sealed class CategoryGetPagedResponse
    {
        /// <summary>
        /// Всего элементов
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Смещение (число элементов)
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Список элементов
        /// </summary>
        public IEnumerable<CategoryGetResponse> Items { get; set; }
    }
}