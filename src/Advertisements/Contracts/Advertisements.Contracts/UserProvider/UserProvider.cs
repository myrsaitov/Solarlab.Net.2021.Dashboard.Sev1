﻿using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Advertisements.Contracts.UserProvider
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

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

            // TODO Считывать из конфига
            string secret = "mySecretKey123asdasdasddasdasd2343423423sdfasd";

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

            // TODO Считывать из конфига
            string secret = "mySecretKey123asdasdasddasdasd2343423423sdfasd";

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


        public bool IsInRole(string role)
        {
            return GetUserRoles().Contains(role);
        }
    }
}