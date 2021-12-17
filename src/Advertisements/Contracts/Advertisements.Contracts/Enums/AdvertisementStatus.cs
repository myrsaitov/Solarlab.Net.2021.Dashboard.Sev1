namespace Sev1.Advertisements.Contracts.Enums

{
    /// <summary>
    /// Статус объявления
    /// </summary>
    public enum AdvertisementStatus
    {
        /// <summary>
        /// Активное (опубликовано)
        /// </summary>
        Active,

        /// <summary>
        /// Снято с публикации
        /// </summary>
        Stopped,

        /// <summary>
        /// Черновик
        /// </summary>
        Draft,

        /// <summary>
        /// Удалено
        /// </summary>
        Deleted,

        /// <summary>
        /// Не соответсвует требованиям
        /// </summary>
        NotAllowed
    }
}