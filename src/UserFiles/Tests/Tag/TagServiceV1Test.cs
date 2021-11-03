using Sev1.UserFiles.MapsterMapper.MapProfiles;
using Sev1.UserFiles.Application.Implementations.Tag;
using Moq;
using MapsterMapper;
using Mapster;
using System.Linq.Expressions;
using Sev1.UserFiles.Application.Repositories.Tag;

namespace Sev1.UserFiles.Tests.Tag
{
    public partial class TagServiceV1Test
    {
        private Mock<ITagRepository> _tagRepositoryMock;
        private IMapper _mapper;

        private TagServiceV1 _tagServiceV1;
        public TagServiceV1Test()
        {
            _tagRepositoryMock = new Mock<ITagRepository>();

            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            _mapper = new Mapper();
            TagMapProfile.GetConfiguredMappingConfig().Compile();

            _tagServiceV1 = new TagServiceV1(
                _tagRepositoryMock.Object,
                _mapper);
        }
    }
}