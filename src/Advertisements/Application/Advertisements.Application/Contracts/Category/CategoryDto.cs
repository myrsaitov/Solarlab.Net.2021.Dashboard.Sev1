namespace Sev1.Advertisements.Application.Contracts.Category
{
    /// <summary>
    /// DTO при получении категории
    /// </summary>
    public class CategoryDto
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