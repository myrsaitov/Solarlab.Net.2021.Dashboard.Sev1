using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Contracts.ApiClients.User;
using System;
using System.Linq;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    [Route("api/v1/advertisements")]
    [ApiController]
    public partial class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IUserApiClient _userApiClient;



        public AdvertisementController(
            IAdvertisementService advertisementService,
            IUserApiClient userApiClient)
        { 
            _advertisementService = advertisementService;
            _userApiClient = userApiClient;
        }
    



        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public System.Threading.Tasks.Task OnAuthorizationAsync(AuthorizationFilterContext context)
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

                var autorizedStatus = await _userApiClient.ValidateToken(
                    accessToken,
                    cancellationToken);

            //var user = (User)context.HttpContext.Items["User"];

            /*if (user == null)
                context.Result = new JsonResult(
                    new { message = "Unauthorized" })
                        { StatusCode = StatusCodes.Status401Unauthorized };*/
            }
        }
    }
}