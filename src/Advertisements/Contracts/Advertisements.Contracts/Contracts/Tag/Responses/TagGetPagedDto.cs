namespace Sev1.Advertisements.Contracts.Contracts.Tag.Responses
{
    /// <summary>
    /// DTO одного тага при запросе пагинации
    /// </summary>
    public class TagGetPagedDto
    {
        /// <summary>
        /// Id тага
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст тага
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Количество объявлений в базе по данному тагу
        /// </summary>
        public int Count { get; set; }
    }
}