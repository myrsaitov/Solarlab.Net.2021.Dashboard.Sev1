using MapsterMapper;
using Sev1.Advertisements.AppServices.Services.Region.Interfaces;
using Sev1.Advertisements.AppServices.Services.Region.Repositories;

namespace Sev1.Advertisements.AppServices.Services.Region.Implementations
{
    public sealed partial class RegionServiceV1 : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionServiceV1(
            IRegionRepository regionRepository,
            IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
    }
}