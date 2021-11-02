using Advertisements.Contracts.UserProvider;
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

        public AdvertisementController(
            IAdvertisementService advertisementService)
        { 
            _advertisementService = advertisementService;
        }
    }
}