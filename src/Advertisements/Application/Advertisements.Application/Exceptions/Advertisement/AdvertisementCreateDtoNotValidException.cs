using Sev1.Advertisements.AppServices.Exceptions.Domain;

namespace Sev1.Advertisements.AppServices.Exceptions.Advertisement
{
    /// <summary>
    /// Исключение при несоответсвующем запросе создания объвления
    /// </summary>
    public class AdvertisementCreateDtoNotValidException : BadRequestException
    {
        public AdvertisementCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}