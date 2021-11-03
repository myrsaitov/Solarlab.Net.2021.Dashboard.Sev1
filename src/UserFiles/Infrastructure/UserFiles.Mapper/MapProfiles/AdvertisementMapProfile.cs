using Mapster;
using Sev1.UserFiles.Application.Contracts.Advertisement;
using System.Linq;

namespace Sev1.UserFiles.MapsterMapper.MapProfiles
{
    public class AdvertisementMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Domain.Advertisement, AdvertisementDto>()
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