using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.Region.Responses
{
    /// <summary>
    /// DTO ответа на запрос пагинации по тагам
    /// </summary>
    public sealed class RegionGetPagedResponseV2
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
        public IEnumerable<RegionGetResponseV2> Items { get; set; }
    }
}