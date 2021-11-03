using Mapster;
using Sev1.UserFiles.Application.Contracts.UserFile;

namespace Sev1.UserFiles.MapsterMapper.MapProfiles
{
    public class UserFileMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Domain.UserFile, UserFileDto>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"));

            config.NewConfig<Domain.UserFile, UserFilePagedDto>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"));
            return config;
        }
    }
}