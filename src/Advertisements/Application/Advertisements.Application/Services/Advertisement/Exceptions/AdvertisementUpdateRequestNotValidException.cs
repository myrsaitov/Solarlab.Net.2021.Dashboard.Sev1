using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions
{
    /// <summary>
    /// Исключение при несоответсвующем запросе обновления
    /// </summary>
    public class AdvertisementUpdateRequestNotValidException : BadRequestException
    {
        public AdvertisementUpdateRequestNotValidException(string message) : base(message)
        {
        }
    }
}