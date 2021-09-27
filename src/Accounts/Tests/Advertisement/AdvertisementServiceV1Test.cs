using Sev1.Accounts.DataAccess.Interfaces;
using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.Accounts.MapsterMapper.MapProfiles;
using Sev1.Accounts.Application.Implementations.Advertisement;

namespace Sev1.Accounts.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        private Mock<IAdvertisementRepository> _advertisementRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<ITagRepository> _tagRepositoryMock;
        private IMapper _mapper;
        
        private AdvertisementServiceV1 _advertisementServiceV1;
        public AdvertisementServiceV1Test()
        {
            _advertisementRepositoryMock = new Mock<IAdvertisementRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _tagRepositoryMock = new Mock<ITagRepository>();


            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            AdvertisementMapProfile.GetConfiguredMappingConfig().Compile();
            CategoryMapProfile.GetConfiguredMappingConfig().Compile();
            TagMapProfile.GetConfiguredMappingConfig().Compile();

            _advertisementServiceV1 = new AdvertisementServiceV1(
                _advertisementRepositoryMock.Object,
                _categoryRepositoryMock.Object, 
                _tagRepositoryMock.Object, 
                _mapper);
        }
    }
}
