using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Services.Advertisement.Contracts.Exceptions
{
    public sealed class AdvertisementNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public AdvertisementNotFoundException(int advertisementId) : base(string.Format(MessageTemplate, advertisementId))
        {
        }
    }
}