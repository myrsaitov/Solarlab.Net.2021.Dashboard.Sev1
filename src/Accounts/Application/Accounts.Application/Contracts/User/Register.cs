namespace Sev1.Accounts.Application.Contracts.User
{
    public static class Register
    {
        /// <summary>
        /// Запрос на регистрацию
        /// </summary>
        public sealed class Request
        {
            /// <summary>
            /// Никнейм пользователя
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Электронная почта пользователя
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Телефон пользователя
            /// </summary>
            public string PhoneNumber { get; set; }

            /// <summary>
            /// Имя пользователя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия пользователя
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Отчество пользователя
            /// </summary>
            public string MiddleName { get; set; }
        }

        /// <summary>
        /// Ответ регистрации
        /// </summary>
        public sealed class Response
        {
            /// <summary>
            /// Id пользователя
            /// </summary>
            public string UserId { get; set; }
        }
    }
}