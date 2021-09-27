using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public sealed class AccountNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        public AccountNotFoundException(int accountId) : base(string.Format(MessageTemplate, accountId))
        {
        }
    }
}