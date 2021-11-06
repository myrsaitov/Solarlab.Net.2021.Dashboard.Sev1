namespace Sev1.Advertisements.Application.Contracts.Advertisement
{
    /// <summary>
    /// DTO при обновлении объявления
    /// </summary>
    public class AdvertisementUpdateDto
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
    }
}