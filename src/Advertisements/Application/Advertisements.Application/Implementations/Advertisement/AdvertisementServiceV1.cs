using MapsterMapper;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Repositories.Advertisement;
using Sev1.Advertisements.Application.Repositories.Category;
using Sev1.Advertisements.Application.Repositories.Tag;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
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