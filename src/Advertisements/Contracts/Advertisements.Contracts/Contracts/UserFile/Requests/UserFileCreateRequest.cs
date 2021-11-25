using System.ComponentModel.DataAnnotations;

namespace Sev1.Advertisements.Contracts.Contracts.Tag.Requests
{
    /// <summary>
    /// DTO при создании тага
    /// </summary>
    public sealed class UserFileCreateRequest
    {
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        [Required]
        public int? FileId { get; set; }
    }
}