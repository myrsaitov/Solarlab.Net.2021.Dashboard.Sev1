using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.Application.Contracts.Advertisement
{
    /// <summary>
    /// DTO запроса на обновление объявления
    /// </summary>
    public class AdvertisementUpdateRequest
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Статус объявления
        /// </summary>
        public AdvertisementStatus Status { get; set; }
    }
}