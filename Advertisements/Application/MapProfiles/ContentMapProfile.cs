using Mapster;
using System.Linq;

namespace Sev1.Advertisements.Application.MapProfiles
{
    public static class AdvertisementMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Domain.Advertisement, Services.Advertisement.Contracts.GetById.Response>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());

            config.NewConfig<Domain.Advertisement, Services.Advertisement.Contracts.GetPaged.Response>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());
            return config;
        }
    }
}