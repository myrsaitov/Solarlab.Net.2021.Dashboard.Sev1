using Mapster;
using Sev1.UserFiles.Application.Contracts.Tag;

namespace Sev1.UserFiles.MapsterMapper.MapProfiles
{
    public class TagMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<TagCreateDto, Domain.Tag>()
                .Map(dest => dest.Body, src => src.Body);

            config.NewConfig<Domain.Tag, TagPagedDto>()
                .Map(dest => dest.Body, src => src.Body);

            return config;
        }
    }
}