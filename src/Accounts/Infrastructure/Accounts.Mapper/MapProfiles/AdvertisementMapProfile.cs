using Mapster;
using Sev1.Accounts.Application.Contracts.Account;
using System.Linq;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class AccountMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Domain.Account, AccountDto>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());

            config.NewConfig<Domain.Account, AccountPagedDto>()
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToLocalTime().ToString("dd/MM/yy H:mm:ss (zzz)"))
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.Tags, src => src.Tags.Select(a => a.Body).ToArray());
            return config;
        }
    }
}