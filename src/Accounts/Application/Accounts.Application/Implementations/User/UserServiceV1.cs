﻿using MapsterMapper;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Application.Interfaces.User;
using Sev1.Accounts.Application.Repository.User;

namespace Sev1.Accounts.Application.Implementations.User
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