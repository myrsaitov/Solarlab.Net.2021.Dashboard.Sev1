using Mapster;
using Sev1.Advertisements.Contracts.Contracts.Tag.Requests;

namespace Sev1.Advertisements.MapsterMapper.MapProfiles
{
    public class TagMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<TagCreateRequest, Domain.Tag>()
                .Map(dest => dest.Body, src => src.Body);

            config.NewConfig<Domain.Tag, TagCreateRequest>()
                .Map(dest => dest.Body, src => src.Body);

            return config;
        }
    }
}