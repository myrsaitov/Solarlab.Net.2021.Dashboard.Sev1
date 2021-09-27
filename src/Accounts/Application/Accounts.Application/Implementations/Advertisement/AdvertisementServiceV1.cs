using MapsterMapper;
using Sev1.Accounts.Application.Interfaces.Advertisement;
using Sev1.Accounts.DataAccess.Interfaces;

namespace Sev1.Accounts.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public AdvertisementServiceV1(
            IAdvertisementRepository advertisementRepository, 
            ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, 
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
    }
}