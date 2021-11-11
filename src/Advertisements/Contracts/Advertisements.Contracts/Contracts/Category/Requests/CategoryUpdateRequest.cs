namespace Sev1.Advertisements.Contracts.Contracts.Category.Requests
{
    /// <summary>
    /// DTO запроса обновления категории
    /// </summary>
    public class CategoryUpdateRequest
    {
        /// <summary>
        /// Id категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        public int? ParentCategoryId { get; set; }
    }
}