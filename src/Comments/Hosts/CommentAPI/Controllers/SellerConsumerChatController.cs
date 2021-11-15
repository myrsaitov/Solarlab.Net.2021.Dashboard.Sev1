using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comments.Services;
using Comments.Contracts;
using Comments.API.Filters;
using System.Threading;

namespace Comments.API.Controllers
{
    /// <summary>
    /// API Чата между пользователем и продавцом
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CommentsExceptionFilter))]
    public class SellerConsumerChatController : ControllerBase
    {
        private readonly ICommentsService _commentService;

        /// <param name="commentService"></param>
        public SellerConsumerChatController(ICommentsService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Получить чат, paged
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("GetChatByAdvertisementIdConsumerIdPaged")]
        public async Task<IActionResult> GetChatByAdvertisementIdConsumerIdPaged([FromQuery] CommentDtoRequestGetByChatId dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _commentService.GetCommentsByChatIdAsync(dto, token));
            }
            return BadRequest();
        }

        /// <summary>
        /// Удалить чат, и комментарии к нему
        /// </summary>
        /// <param name="id">Chat Id</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        [HttpDelete("DeleteChatByAdvertisementId")]
        public async Task<IActionResult> DeleteChatByAdvertisementIdConsumerId([FromQuery] Guid id, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                await _commentService.DeleteCommentsByChatIdAsync(id, token);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Создать комментарий
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Id созданного комментария</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> Add([FromForm] CommentDtoRequestCreate dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.AddCommentAsync(dto, token);
                return Created("", result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Изменить комментарий
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Id обновлённого комментария</returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CommentDtoRequestUpdate dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.UpdateCommentAsync(dto, token);
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Удалить комментирий
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] CommentDtoRequestDelete dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                await _commentService.DeleteCommentAsync(dto, token);
                return Ok();
            }
            return BadRequest();
        }
    }
}
