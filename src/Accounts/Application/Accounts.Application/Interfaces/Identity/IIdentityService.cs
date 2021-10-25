﻿using Sev1.Accounts.Application.Contracts.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Accounts.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<string> GetCurrentUserId(
            CancellationToken cancellationToken);

        Task<bool> IsInRole(
            string userId, 
            string role, 
            CancellationToken cancellationToken);

        Task<CreateUser.Response> CreateUser(
            CreateUser.Request request, 
            CancellationToken cancellationToken);

        Task<CreateToken.Response> CreateToken(
            CreateToken.Request request, 
            CancellationToken cancellationToken);

        Task<string> GetUserRoleById(
            string userId,
            CancellationToken cancellationToken);

        Task<string> GetCurrentUserRole(
            CancellationToken cancellationToken);

        Task<string> SetUserRoleModerator(
            string userId,
            CancellationToken cancellationToken = default);


        /*Task<bool> ConfirmEmail(
            string userId, 
            string token, 
            CancellationToken cancellationToken = default);*/
    }
}
