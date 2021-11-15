using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Exceptions.Category
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