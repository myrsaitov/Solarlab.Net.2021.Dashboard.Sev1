using MapsterMapper;
using Sev1.Advertisements.Application.Identity.Interfaces;
using Sev1.Advertisements.Application.Repositories;
using Sev1.Advertisements.Application.Services.Category.Interfaces;

namespace Sev1.Advertisements.Application.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public CategoryServiceV1(
            ICategoryRepository categoryRepository, 
            IIdentityService identityService, 
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _identityService = identityService;
            _mapper = mapper;
        }
    }
}