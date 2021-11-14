using Sev1.Advertisements.Application.Contracts.Advertisement;
using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.GetPaged.Responses
{
    /// <summary>
    /// DTO ответа на запрос пагинации по объявлениям
    /// </summary>
    public sealed class AdvertisementGetPagedResponse
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
        public IEnumerable<AdvertisementGetPagedDto> Items { get; set; }
    }
}