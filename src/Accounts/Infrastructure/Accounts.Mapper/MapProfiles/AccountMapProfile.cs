using Mapster;
using Sev1.Accounts.Application.Contracts.Enums;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Contracts.User;
using Sev1.Accounts.Contracts.Contracts.User;
using System;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class AccountMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<UserUpdateRequest, Domain.User>()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.CreatedAt, src => DateTime.UtcNow);

            config.NewConfig<UserRegisterRequest, IdentityUserCreateRequestDto>()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Role, src => RoleConstants.User.ToString());

            return config;
        }
    }
}