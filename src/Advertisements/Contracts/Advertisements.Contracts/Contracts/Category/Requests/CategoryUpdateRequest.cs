using System.ComponentModel.DataAnnotations;

namespace Sev1.Advertisements.Contracts.Contracts.Category.Requests
{
    /// <summary>
    /// DTO запроса обновления категории
    /// </summary>
    public sealed class CategoryUpdateRequest
    {
        /// <summary>
        /// Id категории
        /// </summary>
        [Required]
        [Range(1, 100_000_000_000, ErrorMessage = "Значение CategoryId должно быть от 1 до 100_000_000_000")]
        public int Id { get; set; }

        /// <summary>
        /// Имя категории
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина Name не должна превышать 30 символов")]
        public string Name { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        [Range(1, 100_000_000_000, ErrorMessage = "Значение ParentCategoryId должно быть от 1 до 100_000_000_000")]
        public int? ParentCategoryId { get; set; }
    }
}