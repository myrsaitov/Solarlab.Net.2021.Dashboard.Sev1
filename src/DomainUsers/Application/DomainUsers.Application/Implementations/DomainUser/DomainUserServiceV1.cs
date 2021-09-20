using MapsterMapper;

using Sev1.DomainUsers.Application.Interfaces.DomainUser;
using Sev1.DomainUsers.DataAccess.Interfaces;

namespace Sev1.DomainUsers.Application.Implementations.DomainUser
{
    public sealed partial class DomainUserServiceV1 : IDomainUserService
    {
        private readonly IDomainUserRepository _domainUserRepository;
        private readonly IMapper _mapper;

        public DomainUserServiceV1(
            IDomainUserRepository domainUserRepository, 
            IMapper mapper)
        {
            _domainUserRepository = domainUserRepository;
            _mapper = mapper;
        }
    }
}