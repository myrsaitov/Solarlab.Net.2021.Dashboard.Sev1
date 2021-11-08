using System.ComponentModel.DataAnnotations;

namespace NotificationsEmail.Contracts
{
    /// <summary>
    /// Letter Dto
    /// </summary>
    public class LetterDto
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Текст письма
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Email получателя
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
