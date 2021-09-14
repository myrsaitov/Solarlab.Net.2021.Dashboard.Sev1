using Mapster;

namespace Sev1.Advertisements.MapsterMapper.MapProfiles
{
    public class TagMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Application.Contracts.Tag.Create.Request, Domain.Tag>()
                .Map(dest => dest.Body, src => src.Body);

            config.NewConfig<Domain.Tag, Application.Contracts.Tag.GetById.Response>()
                .Map(dest => dest.Body, src => src.Body);

            return config;
        }
    }
}