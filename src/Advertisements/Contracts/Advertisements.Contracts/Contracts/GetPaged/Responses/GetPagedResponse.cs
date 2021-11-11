using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.GetPaged.Responses
{
    /// <summary>
    /// Абстрактный класс респонса на пагинацию
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GetPagedResponse<T>
    {
        /// <summary>
        /// Всего элементов
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Смещение (число элементов)
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Список элементов
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}