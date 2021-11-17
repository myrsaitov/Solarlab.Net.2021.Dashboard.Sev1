using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class AdvertisementGetPagedRequestNotValidException : BadRequestException
    {
        public AdvertisementGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}