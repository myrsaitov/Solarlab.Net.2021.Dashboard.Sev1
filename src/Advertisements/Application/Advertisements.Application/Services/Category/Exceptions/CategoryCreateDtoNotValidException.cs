using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Category.Exceptions
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