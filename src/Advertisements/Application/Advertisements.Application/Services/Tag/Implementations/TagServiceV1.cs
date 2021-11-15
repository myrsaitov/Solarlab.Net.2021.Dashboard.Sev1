using MapsterMapper;
using Sev1.Advertisements.AppServices.Services.Tag.Interfaces;
using Sev1.Advertisements.AppServices.Services.Tag.Repositories;

namespace Sev1.Advertisements.AppServices.Services.Tag.Implementations
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