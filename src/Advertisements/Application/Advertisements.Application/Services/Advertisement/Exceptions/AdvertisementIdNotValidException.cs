using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions
{
    /// <summary>
    /// Исключение при неправильном идентификаторе объявления
    /// </summary>
    public class AdvertisementIdNotValidException : BadRequestException
    {
        public AdvertisementIdNotValidException(string message) : base(message)
        {
        }
    }
}