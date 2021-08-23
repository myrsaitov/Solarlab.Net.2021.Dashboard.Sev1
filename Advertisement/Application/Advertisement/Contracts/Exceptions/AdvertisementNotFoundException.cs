using sev1.Advertisements.Domain.Shared.Exceptions;

namespace sev1.Advertisements.Application.Advertisement.Contracts.Exceptions
{
    public sealed class ContentNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public ContentNotFoundException(int contentId) : base(string.Format(MessageTemplate, contentId))
        {
        }
    }
}