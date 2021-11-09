using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts
{
    public sealed class UserRegisterRequest
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина логина не должна превышать 30 символов")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Максимальная длина Email не должна превышать 100 символов")]
        public string Email { get; set; }

        [MaxLength(30, ErrorMessage = "Максимальная длина имени не должна превышать 30 символов")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Максимальная длина фамилии не должна превышать 30 символов")]
        public string LastName { get; set; }

        [MaxLength(30, ErrorMessage = "Максимальная длина отчества не должна превышать 30 символов")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Максимальная длина номера телефона 15 символов")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}