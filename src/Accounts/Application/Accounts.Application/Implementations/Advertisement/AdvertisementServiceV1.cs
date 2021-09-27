using MapsterMapper;
using Sev1.Accounts.Application.Interfaces.Account;
using Sev1.Accounts.DataAccess.Interfaces;

namespace Sev1.Accounts.Application.Implementations.Account
{
    public sealed partial class AccountServiceV1 : IAccountService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAccountRepository _advertisementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public AccountServiceV1(
            IAccountRepository advertisementRepository, 
            ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, 
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
    }
}