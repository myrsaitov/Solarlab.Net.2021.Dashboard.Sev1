using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.Advertisements.MapsterMapper.MapProfiles;
using Sev1.Advertisements.AppServices.Services.Advertisement.Implementations;
using Sev1.Advertisements.AppServices.Services.Advertisement.Repositories;
using Sev1.Advertisements.AppServices.Services.Category.Repositories;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;
using Sev1.Accounts.Contracts.UserProvider;
using Sev1.Advertisements.AppServices.Services.Region.Repositories;
using Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        private Mock<IAdvertisementRepository> _advertisementRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<ITagRepository> _tagRepositoryMock;
        private Mock<IUserFileRepository> _userFileRepositoryMock;
        private Mock<IRegionRepository> _regionRepositoryMock;
        private Mock<IUserProvider> _userProviderMock;
        private Mock<IUserFilesUploadApiClient> _userFilesUploadApiClientMock;
        private IMapper _mapper;
        
        private AdvertisementServiceV1 _advertisementServiceV1;
        public AdvertisementServiceV1Test()
        {
            _advertisementRepositoryMock = new Mock<IAdvertisementRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _tagRepositoryMock = new Mock<ITagRepository>();
            _userFileRepositoryMock = new Mock<IUserFileRepository>();
            _regionRepositoryMock = new Mock<IRegionRepository>();
            _userProviderMock = new Mock<IUserProvider>();
            _userFilesUploadApiClientMock = new Mock<IUserFilesUploadApiClient>();
            
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            AdvertisementMapProfile.GetConfiguredMappingConfig().Compile();
            CategoryMapProfile.GetConfiguredMappingConfig().Compile();
            TagMapProfile.GetConfiguredMappingConfig().Compile();
            RegionMapProfile.GetConfiguredMappingConfig().Compile();

            _advertisementServiceV1 = new AdvertisementServiceV1(
                _advertisementRepositoryMock.Object,
                _categoryRepositoryMock.Object,
                _tagRepositoryMock.Object,
                _userFileRepositoryMock.Object,
                _regionRepositoryMock.Object,
                _userProviderMock.Object,
                _userFilesUploadApiClientMock.Object,
                _mapper);
        }
    }
}