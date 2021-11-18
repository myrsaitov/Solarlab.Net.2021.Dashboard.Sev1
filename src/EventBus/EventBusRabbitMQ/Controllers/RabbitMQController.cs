using EventBusRabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace EventBusRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQPublisher _publisher;

        /// <param name="commentService"></param>
        public RabbitMQController(IRabbitMQPublisher publisher)
        {
            _publisher = publisher;
        }

        /// <summary>
        /// Опубликоватьс сообщение в очередь rabbitMQ,
        /// use Topic exchange
        /// </summary>
        /// <param name="dto">объект (json)</param>
        /// <param name="routingKey">Направление сообщения</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        public IActionResult PublishObject([FromQuery] string dto, string routingKey,CancellationToken token = default)
        {
            if (dto != null)
            {
                _publisher.Publish(dto, routingKey, null);
                return Ok();
            }
            return BadRequest();
        }
    }
}
