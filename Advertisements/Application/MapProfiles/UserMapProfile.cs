using Mapster;
using Sev1.Advertisements.Application.Common;
using Sev1.Advertisements.Application.Identity.Contracts;
using Sev1.Advertisements.Application.Services.User.Contracts;
using System;

namespace Sev1.Advertisements.Application.MapProfiles
{
    public static class UserMapProfile
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