using Sev1.Advertisements.Application.Implementations.Category;
using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.Advertisements.MapsterMapper.MapProfiles;
using Sev1.Advertisements.Application.Repositories.Category;
using Sev1.Advertisements.Application.Repositories.Tag;
using Sev1.Advertisements.Contracts.ApiClients.User;
using Advertisements.Contracts.UserProvider;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<IUserProvider> _userProviderMock;
        private IMapper _mapper;
        
        private CategoryServiceV1 _categoryServiceV1;
        public CategoryServiceV1Test()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _userProviderMock = new Mock<IUserProvider>();

            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            CategoryMapProfile.GetConfiguredMappingConfig().Compile();
            TagMapProfile.GetConfiguredMappingConfig().Compile();

            _categoryServiceV1 = new CategoryServiceV1(
                _categoryRepositoryMock.Object,
                _userProviderMock.Object,
                _mapper);
        }
    }
}