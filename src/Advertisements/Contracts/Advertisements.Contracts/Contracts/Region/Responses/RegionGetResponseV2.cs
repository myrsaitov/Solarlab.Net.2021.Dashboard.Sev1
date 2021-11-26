namespace Sev1.Advertisements.Contracts.Contracts.Region.Responses
{
    /// <summary>
    /// DTO региона при запросе по идентификатору
    /// </summary>
    public sealed class RegionGetResponseV2
    {
        /// <summary>
        /// Id региона
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Текст тага
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор родительского региона - округ
        /// </summary>
        public int? ParentRegionId { get; set; }
    }
}