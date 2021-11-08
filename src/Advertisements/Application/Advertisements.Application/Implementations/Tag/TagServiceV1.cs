using MapsterMapper;
using Sev1.Advertisements.Application.Interfaces.Tag;
using Sev1.Advertisements.Application.Repositories.Tag;

namespace Sev1.Advertisements.Application.Implementations.Tag
{
    public sealed partial class TagServiceV1 : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagServiceV1(ITagRepository repository, IMapper mapper)
        {
            _tagRepository = repository;
            _mapper = mapper;
        }
    }
}