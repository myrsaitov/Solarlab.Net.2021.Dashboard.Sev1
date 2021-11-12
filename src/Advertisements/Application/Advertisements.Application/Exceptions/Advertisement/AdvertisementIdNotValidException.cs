using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
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