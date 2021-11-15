using MapsterMapper;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Advertisements.AppServices.Services.Interfaces.Advertisement;
using Sev1.Advertisements.AppServices.Services.Repositories.Advertisement;
using Sev1.Advertisements.AppServices.Services.Repositories.Category;
using Sev1.Advertisements.AppServices.Services.Repositories.Tag;

namespace Sev1.Advertisements.AppServices.Services.Implementations.Advertisement
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