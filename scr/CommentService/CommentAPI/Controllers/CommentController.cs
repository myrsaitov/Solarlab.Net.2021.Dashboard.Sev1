using Domain;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contracts;
using System;
using System.Threading.Tasks;

namespace CommentAPI.Controllers
{
    /// <summary>
    /// API комментариев
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        /// <param name="logger"></param>
        /// <param name="commentService"></param>
        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        /// <summary>
        /// Получить комментарий через Id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CommentDtoRequestGet dto)
        {
            try
            {
                return Ok(await _commentService.GetCommentAsync(dto));
            }
            catch (NotFoundException e) 
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Получить все коментарии, прикреплённые к объявлению
        /// 200
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        [HttpGet("GetCommentsByAdvertismentId")]
        public async Task<IActionResult> GetCommentsByAdvertismentId([FromQuery] Guid id)
        {
            // TODO: Передавать признак а не ID
            return Ok(await _commentService.GetCommentsByAdvertismentIdAsync(id));
        }

        /// <summary>
        /// Создать комментарий
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CommentDtoRequestCreate dto)
        {
            if (ModelState.IsValid)
            {
                await _commentService.AddCommentAsync(dto);
                return Created("", null);
            }
            return BadRequest();
        }

        /// <summary>
        /// Изменить комментарий
        /// 200/400/404
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CommentDtoRequestUpdate dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _commentService.UpdateCommentAsync(dto);
                    return Ok();
                } catch (NotFoundException e)
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Удалить комментирий
        /// 200/404
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] CommentDtoRequestDelete dto)
        {
            try
            {
                await _commentService.DeleteCommentAsync(dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }            
        }
    }
}
