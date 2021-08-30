using MapsterMapper;
using Sev1.Advertisements.Application.Identity.Interfaces;
using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Application.Services.Advertisement.Interfaces;

namespace Sev1.Advertisements.Application.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AdvertisementServiceV1(
            IAdvertisementRepository advertisementRepository, 
            ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, 
            IIdentityService identityService, 
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _identityService = identityService;
            _mapper = mapper;
        }
    }
}