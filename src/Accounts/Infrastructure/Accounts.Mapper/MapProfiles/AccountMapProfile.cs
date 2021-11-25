using Mapster;
using Sev1.Accounts.AppServices.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Accounts.Contracts.Enums;
using System;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class AccountMapProfile
    {
        /// <summary>
        /// Конфигурирование маппера
        /// </summary>
        /// <returns></returns>
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<UserUpdateRequest, Domain.User>()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.CreatedAt, src => DateTime.UtcNow);

            config.NewConfig<UserRegisterRequest, IdentityUserCreateRequest>()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Role, src => RoleConstants.User.ToString());

            config.NewConfig<Domain.User, UserGetResponse>()
                .Map(dest => dest.UserId, src => src.Id);

            return config;
        }
    }
}