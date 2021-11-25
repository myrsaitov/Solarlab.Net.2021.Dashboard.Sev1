using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts.Contracts.User.Requests
{
    /// <summary>
    /// Запрос на пагинацию
    /// </summary>
    public sealed class UserGetPagedRequest
    {
        /// <summary>
        /// Количество объектов на странице
        /// </summary>
        [Required]
        [Range(1, 1000, ErrorMessage = "Значение должно быть от 1 до 1000")]
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        [Range(0, 100_000_000_000, ErrorMessage = "Значение Page должно быть от 0 до 100_000_000_000")]
        public int Page { get; set; } = 0;
    }
}