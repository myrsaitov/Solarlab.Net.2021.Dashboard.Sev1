using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Exceptions.Advertisement
{
    /// <summary>
    /// Исключение при несоответсвующем запросе обновления
    /// </summary>
    public class AdvertisementUpdateDtoNotValidException : BadRequestException
    {
        public AdvertisementUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}