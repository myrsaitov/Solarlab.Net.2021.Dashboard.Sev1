using MapsterMapper;
using Sev1.Accounts.Contracts.UserProvider;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Repositories;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;
using Sev1.Advertisements.AppServices.Services.Region.Repositories;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;
using Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserFileRepository _userFileRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IUserProvider _userProvider;
        private readonly IUserFilesUploadApiClient _userFilesUploadApiClient;
        private readonly IMapper _mapper;
        public AdvertisementServiceV1(
            IAdvertisementRepository advertisementRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IUserFileRepository userFileRepository,
            IRegionRepository regionRepository,
            IUserProvider userProvider,
            IUserFilesUploadApiClient userFilesUploadApiClient,
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _userFileRepository = userFileRepository;
            _regionRepository = regionRepository;
            _userProvider = userProvider;
            _userFilesUploadApiClient = userFilesUploadApiClient;
            _mapper = mapper;
        }
    }
}