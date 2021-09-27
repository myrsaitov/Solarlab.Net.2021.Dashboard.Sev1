using Sev1.Accounts.DataAccess.Interfaces;
using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.Accounts.MapsterMapper.MapProfiles;
using Sev1.Accounts.Application.Implementations.Account;

namespace Sev1.Accounts.Tests.Account
{
    public partial class AccountServiceV1Test
    {
        private Mock<IAccountRepository> _advertisementRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<ITagRepository> _tagRepositoryMock;
        private IMapper _mapper;
        
        private AccountServiceV1 _advertisementServiceV1;
        public AccountServiceV1Test()
        {
            _advertisementRepositoryMock = new Mock<IAccountRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _tagRepositoryMock = new Mock<ITagRepository>();


            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            AccountMapProfile.GetConfiguredMappingConfig().Compile();
            CategoryMapProfile.GetConfiguredMappingConfig().Compile();
            TagMapProfile.GetConfiguredMappingConfig().Compile();

            _advertisementServiceV1 = new AccountServiceV1(
                _advertisementRepositoryMock.Object,
                _categoryRepositoryMock.Object, 
                _tagRepositoryMock.Object, 
                _mapper);
        }
    }
}
