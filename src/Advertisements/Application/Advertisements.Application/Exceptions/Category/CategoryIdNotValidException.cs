using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.Category
{
    /// <summary>
    /// Исключение при несоответсвующем идентификаторе при запросе на получение категории
    /// </summary>
    public class CategoryIdNotValidException : BadRequestException
    {
        public CategoryIdNotValidException(string message) : base(message)
        {
        }
    }
}