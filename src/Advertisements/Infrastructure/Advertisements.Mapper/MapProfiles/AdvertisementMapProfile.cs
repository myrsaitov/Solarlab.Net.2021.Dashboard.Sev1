using Mapster;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using System.Linq;

namespace Sev1.Advertisements.MapsterMapper.MapProfiles
{
    public class AdvertisementMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Domain.Advertisement, AdvertisementGetResponse>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());

            config.NewConfig<Domain.Advertisement, AdvertisementPagedDto>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());
            return config;
        }
    }
}