using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Region.Exceptions
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class RegionGetPagedRequestNotValidException : BadRequestException
    {
        public RegionGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}