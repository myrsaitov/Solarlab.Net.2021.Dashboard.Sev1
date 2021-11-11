namespace Sev1.Advertisements.Contracts.Contracts.Category.Responses
{
    /// <summary>
    /// DTO ответа при запросе категории по идентификатору
    /// </summary>
    public class CategoryGetResponse
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
        /// Статус удаления
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}