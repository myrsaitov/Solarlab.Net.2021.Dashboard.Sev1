namespace Sev1.Accounts.Application.Contracts.User
{
    public static class Update
    {
        /// <summary>
        /// Запрос на обновление данных пользователя
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Id пользователя
            /// </summary>
            public string Id { get; set; }

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

            /// <summary>
            /// Никнейм пользователя
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Телефон пользователя
            /// </summary>
            public string PhoneNumber { get; set; }
        }
    }
}
