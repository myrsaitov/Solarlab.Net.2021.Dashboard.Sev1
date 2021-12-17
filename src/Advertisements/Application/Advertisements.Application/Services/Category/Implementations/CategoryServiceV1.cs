using MapsterMapper;
using Sev1.Accounts.Contracts.UserProvider;
using Sev1.Advertisements.AppServices.Services.Category.Interfaces;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;

namespace Sev1.Advertisements.AppServices.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;

        public CategoryServiceV1(
            ICategoryRepository categoryRepository,
            IUserProvider userProvider,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userProvider = userProvider;
            _mapper = mapper;
        }
    }
}