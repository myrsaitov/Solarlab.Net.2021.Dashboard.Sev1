using Mapster;
using Sev1.UserFiles.Contracts.Contracts.UserFile;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;

namespace Sev1.UserFiles.MapsterMapper.MapProfiles
{
    public class UserFileMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

           // config.NewConfig<Domain.UserFile, UserFileGetResponse>()
           //     .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"));

            return config;
        }
    }
}