using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Exceptions.GetPaged
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class GetPagedRequestNotValidException : BadRequestException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}