using MapsterMapper;
using Sev1.Accounts.Application.Interfaces.Tag;
using Sev1.Accounts.DataAccess.Interfaces;

namespace Sev1.Accounts.Application.Implementations.Tag
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