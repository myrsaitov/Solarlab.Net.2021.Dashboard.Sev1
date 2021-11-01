using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Contracts.ApiClients.User;

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
    }
}