﻿using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    /// <summary>
    /// DTO запроса на пагинацию пользовательских файлов
    /// </summary>
    public sealed class UserFileGetPagedRequest
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
    }
}