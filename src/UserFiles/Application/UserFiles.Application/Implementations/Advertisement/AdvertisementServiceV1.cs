using UserFiles.Contracts.UserProvider;
using MapsterMapper;
using Sev1.UserFiles.Application.Interfaces.Advertisement;
using Sev1.UserFiles.Application.Repositories.Advertisement;
using Sev1.UserFiles.Application.Repositories.Category;
using Sev1.UserFiles.Application.Repositories.Tag;
using Sev1.UserFiles.Contracts.ApiClients.User;

namespace Sev1.UserFiles.Application.Implementations.Advertisement
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