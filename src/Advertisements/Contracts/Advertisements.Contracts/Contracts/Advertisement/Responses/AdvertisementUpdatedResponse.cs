using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses
{
    /// <summary>
    /// DTO ответа на запрос обновления объявления
    /// </summary>
    public sealed class AdvertisementUpdatedResponse
    {
        /// <summary>
        /// Статус объявления
        /// </summary>
        public AdvertisementStatus Status { get; set; }
    }
}