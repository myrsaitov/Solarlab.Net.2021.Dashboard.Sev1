using UserFiles.Contracts.UserProvider;
using MapsterMapper;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using Sev1.UserFiles.Application.Repositories.UserFile;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;
        public UserFileServiceV1(
            IUserFileRepository userFileRepository,
            IUserProvider userProvider,
            IMapper mapper)
        {
            _userFileRepository = userFileRepository;
            _userProvider = userProvider;
            _mapper = mapper;
        }
    }
}