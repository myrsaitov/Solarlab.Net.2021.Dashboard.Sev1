using System.Collections.Generic;

namespace Sev1.Accounts.Contracts.Contracts.User.Responses
{
    /// <summary>
    /// DTO ответа на запрос пагинации по тагам
    /// </summary>
    public sealed class UserGetPagedResponse
    {
        /// <summary>
        /// Всего элементов
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Смещение (число элементов)
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Список элементов
        /// </summary>
        public IEnumerable<UserGetResponse> Items { get; set; }
    }
}