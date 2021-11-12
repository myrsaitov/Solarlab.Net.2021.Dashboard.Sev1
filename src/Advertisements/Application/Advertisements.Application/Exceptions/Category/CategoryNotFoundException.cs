using Sev1.Advertisements.Application.Exceptions.Domain;

namespace Sev1.Advertisements.Application.Exceptions.Category
{
    /// <summary>
    /// Исключение, если категория с таким идентификатором не найдена
    /// </summary>
    public sealed class CategoryNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Категория с таким ID[{0}] не была найдена.";
        public CategoryNotFoundException(int Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}