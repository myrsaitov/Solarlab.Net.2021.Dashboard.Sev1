namespace Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests
{
    /// <summary>
    /// Запрос на пагинацию объявлений
    /// </summary>
    public sealed class AdvertisementGetPagedRequest
    {
        /// <summary>
        /// Количество объектов на странице
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// Поиск по строке поиска
        /// </summary>
        public string SearchStr { get; set; }

        /// <summary>
        /// Поиск по таг
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Поиск по категории
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Поиск по Id создавшего объявление
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Поиск по Id региона
        /// </summary>
        public string RegionId { get; set; }
    }
}