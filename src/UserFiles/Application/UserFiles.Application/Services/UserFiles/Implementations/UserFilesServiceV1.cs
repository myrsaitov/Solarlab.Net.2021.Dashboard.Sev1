using MapsterMapper;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using Sev1.UserFiles.AppServices.Services.UserFile.Repositories;
using Microsoft.Extensions.Configuration;
using Sev1.UserFiles.Contracts.ApiClients.YandexDisk;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Avdertisements.Contracts.ApiClients.Advertisement;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Implementations
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly IAdvertisementApiClient _advertisementApiClient;
        private readonly IUserProvider _userProvider;
        private readonly IConfiguration _configuration;
        private readonly IYandexDiskApiClient _yandexDiskApiClient;
        private readonly IMapper _mapper;
        public UserFileServiceV1(
            IUserFileRepository userFileRepository,
            IAdvertisementApiClient advertisementApiClient,
            IUserProvider userProvider,
            IConfiguration configuration,
            IYandexDiskApiClient yandexDiskApiClient,
            IMapper mapper)
        {
            _userFileRepository = userFileRepository;
            _advertisementApiClient = advertisementApiClient;
            _userProvider = userProvider;
            _configuration = configuration;
            _yandexDiskApiClient = yandexDiskApiClient;
            _mapper = mapper;
        }
    }
}