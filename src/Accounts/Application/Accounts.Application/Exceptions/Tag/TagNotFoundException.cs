using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Exceptions.Tag
{
    public sealed class TagNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Tag с таким ID[{0}] не был найдена.";
        public TagNotFoundException(int Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}