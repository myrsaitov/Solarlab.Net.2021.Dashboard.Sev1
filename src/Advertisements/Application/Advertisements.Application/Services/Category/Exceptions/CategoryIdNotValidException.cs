using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Category.Exceptions
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