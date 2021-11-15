using MapsterMapper;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Interfaces;
using Sev1.Accounts.AppServices.Services.User.Repositories;

namespace Sev1.Accounts.AppServices.Services.User.Implementations
{
    public sealed partial class UserServiceV1 : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        public UserServiceV1(
            IUserRepository userRepository, 
            IIdentityService identityService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _identityService = identityService;
            _mapper = mapper;
        }
    }
}