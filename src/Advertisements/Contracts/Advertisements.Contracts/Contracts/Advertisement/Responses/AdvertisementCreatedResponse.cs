namespace Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses
{
    /// <summary>
    /// DTO ответа на запрос создания нового объявления
    /// </summary>
    public sealed class AdvertisementCreatedResponse
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        public int? Id { get; set; }
    }
}