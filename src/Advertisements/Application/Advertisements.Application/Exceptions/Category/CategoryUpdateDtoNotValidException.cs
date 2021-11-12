using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.Category
{
    /// <summary>
    /// Исключение при несоответствующем запросе на обновление категории
    /// </summary>
    public class CategoryUpdateDtoNotValidException : BadRequestException
    {
        public CategoryUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}