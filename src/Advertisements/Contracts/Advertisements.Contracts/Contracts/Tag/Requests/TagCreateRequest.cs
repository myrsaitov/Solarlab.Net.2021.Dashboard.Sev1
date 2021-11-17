using System.ComponentModel.DataAnnotations;

namespace Sev1.Advertisements.Contracts.Contracts.Tag.Requests
{
    /// <summary>
    /// DTO при создании тага
    /// </summary>
    public sealed class TagCreateRequest
    {
        /// <summary>
        /// Текс тага
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина Tag не должна превышать 30")]
        public string Body { get; set; }
    }
}