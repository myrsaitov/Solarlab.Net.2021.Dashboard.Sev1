namespace Sev1.Advertisements.Application.Contracts.GetPaged
{
    /// <summary>
    /// Запрос на пагинацию объявлений
    /// </summary>
    public class GetPagedAdvertisementRequest : GetPagedRequest
    {
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