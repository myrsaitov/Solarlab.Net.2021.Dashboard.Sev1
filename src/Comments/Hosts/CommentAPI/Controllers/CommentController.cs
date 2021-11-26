using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comments.Services;
using Comments.Contracts;
using Comments.API.Filters;
using System.Threading;
using Sev1.Accounts.Contracts.Authorization;

namespace Comments.API.Controllers
{
    /// <summary>
    /// API комментариев
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CommentsExceptionFilter))]
    [Authorize("Administrator", "Moderator", "User")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentsService _commentService;

        /// <param name="logger"></param>
        /// <param name="commentService"></param>
        public CommentController(ILogger<CommentController> logger, ICommentsService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        /// <summary>
        /// Получить чаты пользователя
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("GetUserChatsPaged")]
        public async Task<IActionResult> GetUserChatsPaged([FromQuery] CommentDtoRequestGetUserChatsPaged dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _commentService.GetUserChatsPagedAsync(dto, token));
            }
            return BadRequest();
        }

        /// <summary>
        /// Получить коментарии, постранично
        /// </summary>
        /// <response code="200">Ok</response>
        [AllowAnonymous]
        [HttpGet("GetChatPaged")]
        public async Task<IActionResult> GetChatPaged([FromQuery] CommentDtoRequestGetChatPaged dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _commentService.GetChatPagedAsync(dto, token));
            }
            return BadRequest();
        }

        /// <summary>
        /// Удалить чат
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        [HttpDelete("DeleteChat")]
        public async Task<IActionResult> DeleteChat([FromQuery] CommentDtoRequestDeleteChat dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                await _commentService.DeleteChatAsync(dto, token);
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
        public async Task<IActionResult> Add([FromBody] CommentDtoRequestCreate dto, CancellationToken token = default)
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


        /// <summary>
        /// Получить коментарии чата, от текущего комментария в колличестве quantity
        /// </summary>
        /// <response code="200">Ok</response>
        [AllowAnonymous]
        [HttpGet("GetNextMessagesFromCurrent")]
        public async Task<IActionResult> GetNextMessagesFromCurrent([FromQuery] CommentDtoRequestGetNextFromCurrent dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.GetNextCommentsFromCurrent(dto, token);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
