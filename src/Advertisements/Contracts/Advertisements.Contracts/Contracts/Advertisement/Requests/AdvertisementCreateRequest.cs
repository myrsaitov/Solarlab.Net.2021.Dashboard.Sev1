namespace Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests
{
    /// <summary>
    /// DTO запроса на создание нового объявления
    /// </summary>
    public sealed class AdvertisementCreateRequest
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id категории
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Таги в виде массива строк
        /// </summary>
        public string[] TagBodies { get; set; }
    }
}