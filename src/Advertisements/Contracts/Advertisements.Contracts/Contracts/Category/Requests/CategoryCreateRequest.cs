using System.ComponentModel.DataAnnotations;

namespace Sev1.Advertisements.Contracts.Contracts.Category.Requests
{
    /// <summary>
    /// DTO запроса создания категории
    /// </summary>
    public sealed class CategoryCreateRequest
    {
        /// <summary>
        /// Имя категории
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина Name не должна превышать 30")]
        public string Name { get; set; }

        /// <summary>
        /// Id родительской категории
        /// </summary>
        [Range(1, 100_000_000_000, ErrorMessage = "Значение ParentCategoryId должно быть от 1 до 100_000_000_000")]
        public int? ParentCategoryId { get; set; }
    }
}