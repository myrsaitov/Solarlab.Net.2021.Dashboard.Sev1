namespace Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses
{
    /// <summary>
    /// DTO ответа на запрос обновления объявления
    /// </summary>
    public sealed class AdvertisementUpdatedResponse
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        public int? Id { get; set; }
    }
}