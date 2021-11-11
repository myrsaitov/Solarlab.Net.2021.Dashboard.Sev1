using Sev1.Advertisements.Contracts.Exceptions.Domain;

namespace Sev1.Advertisements.Contracts.Exceptions.Category
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Категория с таким ID[{0}] не была найдена.";
        public CategoryNotFoundException(int Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}