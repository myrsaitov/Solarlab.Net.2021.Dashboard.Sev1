using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Sev1.Accounts.Application.Contracts.Identity;
using Sev1.Accounts.Application.Exceptions.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts;
using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        public async Task<CreateToken.Response> CreateToken(
            CreateToken.Request request, 
            CancellationToken cancellationToken = default)
        {
            // Проверка, существует ли пользователь с таким именем
            var identityUser = await _userManager.FindByNameAsync(
                request.Username);
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

            // Создаем клайм
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Name,
                    request.Username),

                new Claim(
                    ClaimTypes.NameIdentifier,
                    identityUser.Id)
            };

            // Узнаем роли пользователя и добавляем в клаймы
            var userRoles = await _userManager.GetRolesAsync(identityUser);
            claims.AddRange(
                userRoles.Select(
                    role => new Claim(
                        ClaimTypes.Role,
                        role)));

            // Создаем объект с параметрами для генерации токена
            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60), // Продолжительность жизни токена
                notBefore: DateTime.UtcNow,           // Дата и время создания токена
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            _configuration["Token:Key"])), // Ключ из appsettings.json
                    SecurityAlgorithms.HmacSha256          // Выбираем алгоритм шифрования
                )
            );

            // Генерируем токен
            return new CreateToken.Response
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<ValidateTokenResponse> ValidateToken(
                 CancellationToken cancellationToken = default)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            var currentUserId = _userManager.GetUserId(claimsPrincipal);
            var roles = await GetCurrentUserRoles(cancellationToken);

            return new ValidateTokenResponse
            {
                UserId = currentUserId,
                Roles = roles
            };
        }
    }
}