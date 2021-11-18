using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Tag.Exceptions
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class TagGetPagedRequestNotValidException : BadRequestException
    {
        public TagGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}