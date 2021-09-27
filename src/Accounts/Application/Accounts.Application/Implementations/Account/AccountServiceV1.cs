using MapsterMapper;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.DataAccess.Interfaces;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountServiceV1(
            IAccountRepository accountRepository, 
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
    }
}