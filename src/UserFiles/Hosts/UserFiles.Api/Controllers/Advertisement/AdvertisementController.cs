using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Interfaces.Advertisement;

namespace Sev1.UserFiles.Api.Controllers.Advertisement
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