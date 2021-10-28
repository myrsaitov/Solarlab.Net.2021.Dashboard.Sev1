using MapsterMapper;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Repositories.Category;
using Sev1.Advertisements.Contracts.ApiClients.User;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserApiClient _userApiClient;
        private readonly IMapper _mapper;

        public CategoryServiceV1(
            ICategoryRepository categoryRepository,
            IUserApiClient userApiClient,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userApiClient = userApiClient;
            _mapper = mapper;
        }
    }
}