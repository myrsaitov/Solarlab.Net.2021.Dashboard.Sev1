using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        public async Task<IActionResult> Create(
            AdvertisementCreateRequest request, 
            CancellationToken cancellationToken)
        {
            var response = await _advertisementService.Create(new Create.Request
            {
                Title = request.Title,
                Body = request.Body,
                Price = request.Price,
                CategoryId = request.CategoryId,
                TagBodies = request.Tags
            }, cancellationToken);

            return Created($"api/v1/advertisements/{response.Id}", new { });
        }

        public sealed class AdvertisementCreateRequest
        {
            [Required]
            [MaxLength(100)]
            public string Title { get; set; }

            [Required]
            [MaxLength(1000)]
            public string Body { get; set; }

            [Required]
            [Range(0, 100_000_000_000)]
            public decimal Price { get; set; }

            [Required]
            [Range(1, 100_000_000_000)]
            public int CategoryId { get; set; }

            public string[] Tags { get; set; }
        }
    }
}