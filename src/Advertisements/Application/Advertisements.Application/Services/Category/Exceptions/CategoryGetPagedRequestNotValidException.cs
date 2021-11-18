using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Category.Exceptions
{
    /// <summary>
    /// Исключение при нессответсвующем запросе на пагинацию
    /// </summary>
    public class CategoryGetPagedRequestNotValidException : BadRequestException
    {
        public CategoryGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}