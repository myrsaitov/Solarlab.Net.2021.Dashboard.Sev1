using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationsEmail.Contracts;
using NotificationsEmail.Services.Interfaces;

namespace NotificationsEmail.API.Controllers
{
    /// <summary>
    /// API Сервиса нотификации по почте
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsEmailController : ControllerBase
    {
        private readonly ILogger<NotificationsEmailController> _logger;
        private readonly INotificationEmailService _notificationEmailService;

        public NotificationsEmailController(ILogger<NotificationsEmailController> logger, INotificationEmailService notificationEmailService)
        {
            _logger = logger;
            _notificationEmailService = notificationEmailService;
        }

        /// <summary>
        /// Отправить Email
        /// </summary>
        /// <param name="dto">Письмо</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendEmail([FromForm] LetterDto dto)
        {
            if (ModelState.IsValid)
            {
                _notificationEmailService.SendNewEmailAsync(dto);
                return Ok();
            }
            return BadRequest();
        }
    }
}
