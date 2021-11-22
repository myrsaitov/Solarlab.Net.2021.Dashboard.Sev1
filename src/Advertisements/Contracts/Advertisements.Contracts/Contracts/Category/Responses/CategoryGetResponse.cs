namespace Sev1.Advertisements.Contracts.Contracts.Category.Responses
{
    /// <summary>
    /// DTO ответа при запросе категории по идентификатору
    /// </summary>
    public sealed class CategoryGetResponse
    {
        /// <summary>
        /// Id категории
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id родительской категории
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Количество объявлений в базе по данной категории
        /// </summary>
        public int? Count { get; set; }
    }
}