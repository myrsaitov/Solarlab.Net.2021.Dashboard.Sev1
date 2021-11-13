using System.ComponentModel.DataAnnotations;

namespace Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests
{
    /// <summary>
    /// Запрос на пагинацию объявлений
    /// </summary>
    public sealed class AdvertisementGetPagedRequest
    {
        /// <summary>
        /// Количество объектов на странице
        /// </summary>
        [Required]
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        [Range(0, 100_000_000_000, ErrorMessage = "Значение Page должно быть от 0 до 100_000_000_000")]
        public int Page { get; set; } = 0;

        /// <summary>
        /// Поиск по строке поиска
        /// </summary>
        [MaxLength(100, ErrorMessage = "Максимальная длина SearchStr не должна превышать 100")]
        public string SearchStr { get; set; }

        /// <summary>
        /// Поиск по таг
        /// </summary>
        [MaxLength(30, ErrorMessage = "Максимальная длина Tag не должна превышать 30")]
        public string Tag { get; set; }

        /// <summary>
        /// Поиск по категории
        /// </summary>
        [Range(1, 100_000_000_000, ErrorMessage = "Значение CategoryId должно быть от 1 до 100_000_000_000")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Поиск по Id создавшего объявление
        /// </summary>
        [StringLength(36, ErrorMessage = "Длина UserId должна быть 36 символов")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Поиск по Id региона
        /// </summary>
        [StringLength(36, ErrorMessage = "Длина RegionId должна быть 36 символов")]
        public string RegionId { get; set; }
    }
}