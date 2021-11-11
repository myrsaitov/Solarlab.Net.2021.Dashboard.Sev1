namespace Sev1.Advertisements.Contracts.Contracts.Category
{
    /// <summary>
    /// DTO при создании категории
    /// </summary>
    public class CategoryCreateDto
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