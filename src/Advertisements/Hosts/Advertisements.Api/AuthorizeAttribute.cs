using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorizationAsync(AuthorizationFilterContext context)
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

            // var autorizedStatus = await _userApiClient.ValidateToken(
            //    accessToken,
            //   cancellationToken);

            var user = "11111";// (User)context.HttpContext.Items["User"];

            if (user == null)
                context.Result = new JsonResult(
                    new { message = "Unauthorized" })
                        { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
