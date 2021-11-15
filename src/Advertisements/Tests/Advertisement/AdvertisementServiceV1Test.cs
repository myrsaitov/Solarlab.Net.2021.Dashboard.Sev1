using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.Advertisements.MapsterMapper.MapProfiles;
using Sev1.Advertisements.AppServices.Services.Implementations.Advertisement;
using Sev1.Advertisements.AppServices.Services.Repositories.Advertisement;
using Sev1.Advertisements.AppServices.Services.Repositories.Category;
using Sev1.Advertisements.AppServices.Services.Repositories.Tag;
using sev1.Accounts.Contracts.UserProvider;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        private Mock<IAdvertisementRepository> _advertisementRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<ITagRepository> _tagRepositoryMock;
        private Mock<IUserProvider> _userProviderMock;
        private IMapper _mapper;
        
        private AdvertisementServiceV1 _advertisementServiceV1;
        public AdvertisementServiceV1Test()
        {
            _advertisementRepositoryMock = new Mock<IAdvertisementRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _tagRepositoryMock = new Mock<ITagRepository>();
            _userProviderMock = new Mock<IUserProvider>();

            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            AdvertisementMapProfile.GetConfiguredMappingConfig().Compile();
            CategoryMapProfile.GetConfiguredMappingConfig().Compile();
            TagMapProfile.GetConfiguredMappingConfig().Compile();

            _advertisementServiceV1 = new AdvertisementServiceV1(
                _advertisementRepositoryMock.Object,
                _categoryRepositoryMock.Object,
                _tagRepositoryMock.Object,
                _userProviderMock.Object,
                _mapper);
        }
    }
}