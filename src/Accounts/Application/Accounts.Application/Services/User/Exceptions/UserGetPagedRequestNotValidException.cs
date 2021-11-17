using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Region.Exceptions
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class UserGetPagedRequestNotValidException : BadRequestException
    {
        public UserGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}