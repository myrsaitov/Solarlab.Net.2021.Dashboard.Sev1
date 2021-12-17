using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Sev1.Accounts.Contracts.UserProvider
{
    /// <summary>
    /// Возвращает идентификатор и роли авторизированного пользователя
    /// </summary>
    public sealed class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        public UserProvider(
            IHttpContextAccessor context,
            IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration;
        }

        /// <summary>
        /// Возвращает идентификатор авторизированного пользователя
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            // Получаем токен, отрезав от хидера начало с "Bearer "
            var token = _context
                .HttpContext
                .Request
                .Headers["Authorization"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            // Если JWT-токена не существует, то пользователь анонимный
            if (string.IsNullOrWhiteSpace(token))
            {
                return "Anonymous";
            }

            // Считыватем ключ из конфига "appsettings.json"
            string secret = _configuration["Token:Key"];

            var key = Encoding.UTF8.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            return claims.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        }

        /// <summary>
        /// Возвращает роли авторизированного пользователя
        /// </summary>
        /// <returns></returns>
        public string[] GetUserRoles()
        {
            // Получаем токен, отрезав от хидера начало с "Bearer "
            var token = _context
                .HttpContext
                .Request
                .Headers["Authorization"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            // Если JWT-токена не существует, то пользователь анонимный
            if(string.IsNullOrWhiteSpace(token))
            {
                return new string[]
                {
                    "Anonymous"
                };
            }

            // Считыватем ключ из конфига "appsettings.json"
            string secret = _configuration["Token:Key"];

            var key = Encoding.UTF8.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            var roles = claims
                .Claims
                .Where(claim => claim.Type == ClaimTypes.Role)
                .Select(a => a.Value)
                .ToArray();
            
            return roles;
        }

        /// <summary>
        /// Проверяет, есть ли указанная роль у авторизированного пользователя
        /// </summary>
        /// <param name="role">Роль, которая проверяется</param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            return GetUserRoles().Contains(role);
        }

        /// <summary>
        /// Возвращает Authorization Header
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizationHeader()
        {
            return _context
                .HttpContext
                .Request
                .Headers["Authorization"]
                .FirstOrDefault();
        }
    }
}