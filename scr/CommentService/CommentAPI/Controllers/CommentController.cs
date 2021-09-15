﻿using Domain;
using Microsoft.Extensions.Logging;
using Contracts;
using System;
using System.Threading.Tasks;
using Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CommentAPI.Controllers
{
    /// <summary>
    /// API комментариев
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CommentExceptionFilter))]
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
        /// Получить все коментарии, прикреплённые к чату
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("GetCommentsByChatIdAsync")]
        public async Task<IActionResult> GetCommentsByChatId([FromQuery] CommentDtoRequestGetByChatId dto)
        {
            var token = HttpContext.RequestAborted;

            if (ModelState.IsValid)
            {
                return Ok(await _commentService.GetCommentsByChatIdAsync(dto, token));
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
        public async Task<IActionResult> DeleteCommentsByChatId([FromQuery] Guid id)
        {
            if (ModelState.IsValid)
            {
                await _commentService.DeleteCommentsByChatIdAsync(id);
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
        public async Task<IActionResult> Add([FromForm] CommentDtoRequestCreate dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.AddCommentAsync(dto);
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
        public async Task<IActionResult> Update([FromForm] CommentDtoRequestUpdate dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.UpdateCommentAsync(dto);
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
        public async Task<IActionResult> Delete([FromQuery] CommentDtoRequestDelete dto)
        {
            if (ModelState.IsValid)
            {
                await _commentService.DeleteCommentAsync(dto);
                return Ok();
            }
            return BadRequest();
        }
    }
}
