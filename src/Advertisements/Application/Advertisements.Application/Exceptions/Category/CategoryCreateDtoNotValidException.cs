using Sev1.Advertisements.AppServices.Exceptions.Domain;

namespace Sev1.Advertisements.AppServices.Exceptions.Category
{
    /// <summary>
    /// Исключение при несоответствующем запросе при создании категории
    /// </summary>
    public class CategoryCreateDtoNotValidException : BadRequestException
    {
        public CategoryCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}