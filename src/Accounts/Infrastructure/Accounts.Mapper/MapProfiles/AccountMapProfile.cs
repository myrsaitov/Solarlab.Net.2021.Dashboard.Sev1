using Mapster;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Contracts.User;
using System;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class AccountMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<CreateUser.Response, Register.Response>()
                .Map(dest => dest.UserId, src => src.UserId);

            config.NewConfig<Update.Request, Domain.User>()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.CreatedAt, src => DateTime.UtcNow);

            config.NewConfig<Register.Request, CreateUser.Request>()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Role, src => RoleConstants.UserRole);

            return config;
        }
    }
}