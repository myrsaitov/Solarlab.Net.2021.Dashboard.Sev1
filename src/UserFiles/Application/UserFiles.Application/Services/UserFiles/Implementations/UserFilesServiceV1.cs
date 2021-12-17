using MapsterMapper;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using Sev1.UserFiles.AppServices.Services.UserFile.Repositories;
using Microsoft.Extensions.Configuration;
using Sev1.UserFiles.Contracts.ApiClients.YandexDisk;
using Sev1.Accounts.Contracts.UserProvider;
using Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Implementations
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly IAdvertisementValidateApiClient _advertisementValidateApiClient;
        private readonly IUserProvider _userProvider;
        private readonly IConfiguration _configuration;
        private readonly IYandexDiskApiClient _yandexDiskApiClient;
        private readonly IMapper _mapper;
        public UserFileServiceV1(
            IUserFileRepository userFileRepository,
            IAdvertisementValidateApiClient advertisementValidateApiClient,
            IUserProvider userProvider,
            IConfiguration configuration,
            IYandexDiskApiClient yandexDiskApiClient,
            IMapper mapper)
        {
            _userFileRepository = userFileRepository;
            _advertisementValidateApiClient = advertisementValidateApiClient;
            _userProvider = userProvider;
            _configuration = configuration;
            _yandexDiskApiClient = yandexDiskApiClient;
            _mapper = mapper;
        }
    }
}