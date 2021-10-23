using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Interfaces.User;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    [Route("api/v1/advertisements")]
    [ApiController]
    //[Authorize]
    public partial class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IUserService _userService;
        public AdvertisementController(
            IAdvertisementService advertisementService,
            IUserService userService)
        { 
            _advertisementService = advertisementService;
            _userService = userService;
        }
    }
}