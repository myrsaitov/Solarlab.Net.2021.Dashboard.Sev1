using MapsterMapper;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using Sev1.Advertisements.AppServices.Services.Advertisement.Repositories;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;
        public AdvertisementServiceV1(
            IAdvertisementRepository advertisementRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IUserProvider userProvider,
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _userProvider = userProvider;
            _mapper = mapper;
        }
    }
}