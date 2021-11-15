using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Tag.Exceptions
{
    /// <summary>
    /// Исключение, если не найден таг с таким идентификатором
    /// </summary>
    public sealed class TagNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Tag с таким ID[{0}] не был найдена.";
        public TagNotFoundException(int Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}