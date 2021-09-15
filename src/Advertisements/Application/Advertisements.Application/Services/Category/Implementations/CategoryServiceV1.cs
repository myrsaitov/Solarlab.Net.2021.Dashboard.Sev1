using MapsterMapper;

using Sev1.Advertisements.Application.Services.Category.Interfaces;
using Sev1.Advertisements.DataAccess.Interfaces;

namespace Sev1.Advertisements.Application.Services.Category.Implementations
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServiceV1(
            ICategoryRepository categoryRepository, 
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
    }
}