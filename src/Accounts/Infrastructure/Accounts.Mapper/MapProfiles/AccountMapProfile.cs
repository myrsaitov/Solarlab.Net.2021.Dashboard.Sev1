using Mapster;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class AccountMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            /*config.NewConfig<AccountCreateDto, Domain.Account>()
                .Map(dest => dest.Body, src => src.Body);*/


            return config;
        }
    }
}