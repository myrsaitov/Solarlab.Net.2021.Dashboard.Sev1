using UserFiles.Contracts.UserProvider;
using MapsterMapper;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using Sev1.UserFiles.Application.Repositories.UserFile;
using Sev1.UserFiles.Contracts.ApiClients.Advertisement;
using Microsoft.Extensions.Configuration;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly IAdvertisementApiClient _advertisementApiClient;
        private readonly IUserProvider _userProvider;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserFileServiceV1(
            IUserFileRepository userFileRepository,
            IAdvertisementApiClient advertisementApiClient,
            IUserProvider userProvider,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userFileRepository = userFileRepository;
            _advertisementApiClient = advertisementApiClient;
            _userProvider = userProvider;
            _configuration = configuration;
            _mapper = mapper;
        }
    }
}