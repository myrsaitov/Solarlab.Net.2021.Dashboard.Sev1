using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;

namespace Sev1.UserFiles.Api.Controllers.UserFile
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
            UserFileGetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            var result = await _userFileService.GetPaged(
                request, 
                cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Возвращает файл по Id
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] // Get values from route data, e.g.: "/api/v1/userfiles/{id}"
            int? id, 
            CancellationToken cancellationToken)
        {
            var found = await _userFileService.GetById(
                id,
                cancellationToken);

            return Ok(found);
        }
    }
}