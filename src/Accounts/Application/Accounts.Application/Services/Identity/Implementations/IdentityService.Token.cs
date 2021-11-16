using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;
using Sev1.Accounts.Contracts.Contracts.User.Requests;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Accounts.Domain.Base.Exceptions;
using Sev1.Accounts.AppServices.Services.Identity.Exceptions;
using Sev1.Accounts.Contracts.Contracts.Identity.Responses;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="request">E-mail и пароль</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<IdentityUserCreateTokenResponse> CreateToken(
            UserLoginRequest request, 
            CancellationToken cancellationToken = default)
        {
            // TODO Validator

            // Проверка, существует ли пользователь с таким именем
            var identityUser = await _userManager.FindByEmailAsync(
                request.EMail);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            // Проверка пароля
            var passwordCheckResult = await _userManager.CheckPasswordAsync(
                identityUser, 
                request.Password);
            if (!passwordCheckResult)
            {
                throw new NoRightsException("Неправильный логин или пароль");
            }

            // Создает клайм
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Email,
                    request.EMail),

                new Claim(
                    ClaimTypes.NameIdentifier,
                    identityUser.Id)
            };

            // Узнает роли пользователя и добавляет в клаймы
            var userRoles = await _userManager.GetRolesAsync(identityUser);
            claims.AddRange(
                userRoles.Select(
                    role => new Claim(
                        ClaimTypes.Role,
                        role)));

            // Создает объект с параметрами для генерации токена
            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60), // Продолжительность жизни токена
                notBefore: DateTime.UtcNow,           // Дата и время создания токена
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            _configuration["Token:Key"])), // Ключ из appsettings.json
                    SecurityAlgorithms.HmacSha256          // Выбирает алгоритм шифрования
                )
            );

            // Генерирует ответ
            return new IdentityUserCreateTokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = identityUser.Id,
                Roles = userRoles
            };
        }

        /// <summary>
        /// Проверка, аутентифицирован ли пользователь,
        /// если да, то возвращает его роль и идентификатор
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<ValidateTokenResponse> ValidateToken(
                 CancellationToken cancellationToken = default)
        {
            // Возвращает клаймы из HTTP
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;

            // Возвращает идентификатор авторизированного пользователя
            var currentUserId = _userManager.GetUserId(claimsPrincipal);
            if(string.IsNullOrWhiteSpace(currentUserId))
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            // Возвращает роли пользователя
            var roles = await GetCurrentUserRoles(cancellationToken);
            if (roles is null)
            {
                throw new RoleNotFoundException("Роли не найдены");
            }

            // Возвращает ответ
            return new ValidateTokenResponse
            {
                UserId = currentUserId,
                Roles = roles
            };
        }
    }
}