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
    /// API комментариев
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CommentsExceptionFilter))]
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
        /// Получить все коментарии, прикреплённые к чату
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("GetCommentsByChatId")]
        public async Task<IActionResult> GetCommentsByChatId([FromQuery] CommentDtoRequestGetByChatId dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _commentService.GetCommentsByChatIdAsync(dto, token));
            }
            return BadRequest();
        }

        /// <summary>
        /// Посчитать количество страниц комментариев в чате
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("CountPagesByChatId")]
        public async Task<IActionResult> CountPagesByChatId([FromQuery] CommentDtoRequestCountPagesByChatId dto, CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _commentService.CountPagesAsync(dto.Id, dto.PageSize, token));
            }
            return BadRequest();
        }

        /// <summary>
        /// Удалить все коментарии, прикреплённые к чату
        /// </summary>
        /// <param name="id">Chat Id</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        [HttpDelete("DeleteCommentsByChatId")]
        public async Task<IActionResult> DeleteCommentsByChatId([FromQuery] Guid id, CancellationToken token = default)
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
