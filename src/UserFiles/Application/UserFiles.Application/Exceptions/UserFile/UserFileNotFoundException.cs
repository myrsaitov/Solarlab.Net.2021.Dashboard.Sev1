using Sev1.UserFiles.Domain.Exceptions;

namespace Sev1.UserFiles.Application.Exceptions.UserFile
{
    public sealed class UserFileNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public UserFileNotFoundException(int userFileId) : base(string.Format(MessageTemplate, userFileId))
        {
        }
    }
}