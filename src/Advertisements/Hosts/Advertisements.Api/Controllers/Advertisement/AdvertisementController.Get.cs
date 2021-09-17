using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Api.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementService.GetPaged(
                request, 
                cancellationToken);
            
            
            
            /*
            
            var result = new GetPagedResponse<AdvertisementPagedDto>();

            if((request.SearchStr is null) 
                && (request.UserName is null) 
                && (request.CategoryId is null) 
                && (request.Tag is null))
            {
                result = await _advertisementService.GetPaged(new GetPagedRequest
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);
            }
            else if ((request.SearchStr is not null) 
                && (request.UserName is null) 
                && (request.CategoryId is null) 
                && (request.Tag is null))
            {
                // Общий поиск
                result = await _advertisementService.GetPaged(
                    o => o.Body.ToLower().Contains(request.SearchStr.ToLower())  // В теле объявления
                    || o.Title.ToLower().Contains(request.SearchStr.ToLower())  // В названии объявления
                    || o.Category.Name.ToLower().Contains(request.SearchStr.ToLower()) // По имени категории
                    || o.Tags.Select(a => a.Body).ToArray().Contains(request.SearchStr.ToLower()), // По  tag
                    new GetPagedRequest
                    {
                        PageSize = request.PageSize,
                        Page = request.Page
                    }, cancellationToken);
            }
            else if ((request.SearchStr is null) 
                && (request.UserName is null) 
                && (request.CategoryId is not null) 
                && (request.Tag is null))
            {
                // Поиск по CategoryId
                result = await _advertisementService.GetPaged(
                    a => a.CategoryId == request.CategoryId,
                    new GetPagedRequest
                    {
                        PageSize = request.PageSize,
                        Page = request.Page
                    }, cancellationToken);
            }
            else if ((request.SearchStr is null) 
                && (request.UserName is null) 
                && (request.CategoryId is null) 
                && (request.Tag is not null))
            {
                // Поиск по Tag
                result = await _advertisementService.GetPaged(
                    a => a.Tags.Any(t => t.Body == request.Tag),
                    new GetPagedRequest
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);
            }
            */

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id, 
            CancellationToken cancellationToken)
        {
            var found = await _advertisementService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}