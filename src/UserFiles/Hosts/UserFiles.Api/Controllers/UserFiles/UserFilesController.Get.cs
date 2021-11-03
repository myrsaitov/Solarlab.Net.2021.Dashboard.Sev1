using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Contracts.GetPaged;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.Advertisement
{
    public partial class UserFilesController
    {
        /// <summary>
        /// Возвращает список файлов с пагинацией (и поиском)
        /// </summary>
        /// <param name="request">Запрос на пагинацию и поиск</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] // Get values from the query string, e.g.: ?PageSize=10&Page=0
            GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementService.GetPaged(
                request, 
                cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Возвращает файл по Id
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/advertisements/{id}"
            int id, 
            CancellationToken cancellationToken)
        {
            var found = await _advertisementService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}