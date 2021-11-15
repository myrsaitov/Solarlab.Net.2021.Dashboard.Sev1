using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Exceptions.Advertisement
{
    /// <summary>
    /// Исключение, когда объявление с таким идентификатором не найдено
    /// </summary>
    public sealed class AdvertisementNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public AdvertisementNotFoundException(int? advertisementId) : base(string.Format(MessageTemplate, advertisementId))
        {
        }
    }
}