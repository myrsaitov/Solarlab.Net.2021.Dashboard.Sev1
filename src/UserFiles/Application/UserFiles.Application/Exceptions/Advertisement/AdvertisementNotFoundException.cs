using Sev1.UserFiles.Domain.Exceptions;

namespace Sev1.UserFiles.Application.Exceptions.Advertisement
{
    public sealed class AdvertisementNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public AdvertisementNotFoundException(int advertisementId) : base(string.Format(MessageTemplate, advertisementId))
        {
        }
    }
}