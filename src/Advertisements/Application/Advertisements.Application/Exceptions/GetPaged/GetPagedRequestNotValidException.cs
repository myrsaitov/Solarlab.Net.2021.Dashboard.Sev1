using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.GetPaged
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