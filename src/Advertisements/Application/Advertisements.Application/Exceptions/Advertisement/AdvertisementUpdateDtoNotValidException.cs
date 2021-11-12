using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
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