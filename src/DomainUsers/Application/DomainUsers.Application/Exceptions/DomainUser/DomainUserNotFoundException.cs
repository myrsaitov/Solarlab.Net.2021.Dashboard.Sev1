using Sev1.DomainUsers.Domain.Exceptions;

namespace Sev1.DomainUsers.Application.Exceptions.DomainUser
{
    public sealed class DomainUserNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Пользователь с таким ID[{0}] не был найден.";
        public DomainUserNotFoundException(int advertisementId) : base(string.Format(MessageTemplate, advertisementId))
        {
        }
    }
}