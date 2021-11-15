using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Exceptions.Category
{
    /// <summary>
    /// Исключение при несоответствующем запросе на обновление категории
    /// </summary>
    public class CategoryUpdateRequestNotValidException : BadRequestException
    {
        public CategoryUpdateRequestNotValidException(string message) : base(message)
        {
        }
    }
}