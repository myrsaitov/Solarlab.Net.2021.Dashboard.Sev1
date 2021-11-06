namespace Sev1.Advertisements.Application.Contracts.Tag
{
    /// <summary>
    /// DTO тага
    /// </summary>
    public class TagPagedDto
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