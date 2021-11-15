using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Sev1.Accounts.Contracts.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context
               .ActionDescriptor
               .EndpointMetadata
               .OfType<AllowAnonymousAttribute>()
               .Any();

            if (allowAnonymous)
                return;

            // authorization
            var authorized = false;

            var user = context.HttpContext.Items["User"];
            var moderator = context.HttpContext.Items["Moderator"];
            var admin = context.HttpContext.Items["Administrator"];

            // Исключение, если _roles == null
            if (_roles is null)
            {
                throw new ArgumentNullException(nameof(_roles));
            }

            // Авторизация по ролям
            if (_roles.Count() == 0)
            {
                // Если роли не переданы в виде параметра, 
                // т.е. достаточно просто авторизации
                if ((user == null) &&
                    (moderator == null) &&
                    (admin == null))
                {
                    // Если все роли нулл, то авторизация не прошла
                    authorized = false;
                }
                else
                {
                    // Если хотябы одна ролей не нулл, то безролевая авторизация прошла
                    authorized = true;
                }
            }
            else
            {
                // Проверяем каждую роль по отдельности
                foreach (var role in _roles)
                {
                    switch (role)
                    {
                        case "Administrator":
                            if (admin is not null)
                            {
                                authorized = true;
                            }
                            break;

                        case "Moderator":
                            if (moderator is not null)
                            {
                                authorized = true;
                            }
                            break;

                        case "User":
                            if (user is not null)
                            {
                                authorized = true;
                            }
                            break;
                    }
                }
            }

            // Если авторицазии нет, то прерываем middleware
            if (!authorized)
            {
                context.Result = new JsonResult(
                    new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}