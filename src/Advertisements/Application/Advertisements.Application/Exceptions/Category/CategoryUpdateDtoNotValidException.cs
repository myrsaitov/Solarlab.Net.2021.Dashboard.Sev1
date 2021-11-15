using Sev1.Advertisements.AppServices.Exceptions.Domain;

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