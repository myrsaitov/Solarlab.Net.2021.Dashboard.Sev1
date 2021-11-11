namespace Sev1.Advertisements.Contracts.Contracts.Category.Requests
{
    /// <summary>
    /// DTO запроса создания категории
    /// </summary>
    public class CategoryCreateRequest
    {
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id родительской категории
        /// </summary>
        public int? ParentCategoryId { get; set; }
    }
}