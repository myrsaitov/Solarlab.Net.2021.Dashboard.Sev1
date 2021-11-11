using Sev1.Advertisements.Contracts.Exceptions.Domain;

namespace Sev1.Advertisements.Contracts.Exceptions.Tag
{
    public sealed class TagNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Tag с таким ID[{0}] не был найдена.";
        public TagNotFoundException(int Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}