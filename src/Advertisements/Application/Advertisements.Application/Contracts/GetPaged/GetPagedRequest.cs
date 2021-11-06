namespace Sev1.Advertisements.Application.Contracts.GetPaged
{
    /// <summary>
    /// Запрос на пагинацию
    /// </summary>
    public class GetPagedRequest
    {
        /// <summary>
        /// Количество объектов на странице
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; } = 0;
    }
}