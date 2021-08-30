using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Advertisement.Interfaces;

namespace Sev1.API.Controllers.Advertisement
{
    [Route("api/v1/advertisements")]
    [ApiController]
    [Authorize]
    public partial class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService) => _advertisementService = advertisementService;
    }
}