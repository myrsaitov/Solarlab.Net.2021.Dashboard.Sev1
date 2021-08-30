using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Advertisement.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Contracts;
using System.Linq;

namespace Sev1.API.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaged([FromQuery] GetPagedAdvertisementRequest request, CancellationToken cancellationToken)
        {
            var result = new Paged.Response<GetPaged.Response>();

            if((request.SearchStr is null) 
                && (request.UserName is null) 
                && (request.CategoryId is null) 
                && (request.Tag is null))
            {
                result = await _advertisementService.GetPaged(new Paged.Request
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
                    || o.Owner.UserName.ToLower().Contains(request.SearchStr.ToLower()) // В UserName
                    || o.Category.Name.ToLower().Contains(request.SearchStr.ToLower()) // По имени категории
                    || o.Tags.Select(a => a.Body).ToArray().Contains(request.SearchStr.ToLower()), // По  tag
                    new Paged.Request
                    {
                        PageSize = request.PageSize,
                        Page = request.Page
                    }, cancellationToken);
            }
            else if ((request.SearchStr is null) 
                && (request.UserName is not null) 
                && (request.CategoryId is null) 
                && (request.Tag is null))
            {
                // Поиск по UserName
                result = await _advertisementService.GetPaged(
                    a => a.Owner.UserName == request.UserName,
                    new Paged.Request
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
                    new Paged.Request
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
                    new Paged.Request
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, cancellationToken);
            }


            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(
            int id, 
            CancellationToken cancellationToken)
        {
            var found = await _advertisementService.GetById(new GetById.Request
            {
                Id = id
            },
            cancellationToken);

            return Ok(found);
        }
    }
}