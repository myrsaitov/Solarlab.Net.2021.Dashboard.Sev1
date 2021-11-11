﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sev1.Accounts.Application.Interfaces.Identity;
using Sev1.Accounts.Contracts.Contracts.Identity.Requests;
using Sev1.Accounts.Contracts.Contracts.Identity.Responses;
using Sev1.Accounts.Contracts.Exceptions;
using Sev1.Accounts.Contracts.Exceptions.Domain;

namespace Sev1.Accounts.Application.Implementations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Зарегистрировать пользователя в Identity
        /// </summary>
        /// <param name="dto">DTO с данными пользователя</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<IdentityUserCreateResponse> CreateUser(
            IdentityUserCreateRequest request, 
            CancellationToken cancellationToken = default)
        {
            // Проверка, существует ли такой пользователь в базе
            var existedUser = await _userManager
                .FindByEmailAsync(
                request.Email);
            if (existedUser != null)
            {
                throw new ConflictException("Пользователь с таким Email уже существует");
            }

            // Создаем пользователя
            var identityUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            // Помещаем его в базу
            var identityResult = await _userManager
                .CreateAsync(
                    identityUser,
                    request.Password);

            // Если удачно, то возвращаем положительный ответ
            if (identityResult.Succeeded)
            {
                await _userManager
                    .AddToRoleAsync(
                        identityUser,
                        request.Role);

                return new IdentityUserCreateResponse
                {
                    UserId = identityUser.Id,
                    IsSuccess = true
                };

                // TODO нотификация по Email - подключить
            }

            // Иначе - отрицательный
            return new IdentityUserCreateResponse
            {
                IsSuccess = false,
                Errors = identityResult
                    .Errors
                    .Select(x => x.Description)
                    .ToArray()
            };
        }
    }
}