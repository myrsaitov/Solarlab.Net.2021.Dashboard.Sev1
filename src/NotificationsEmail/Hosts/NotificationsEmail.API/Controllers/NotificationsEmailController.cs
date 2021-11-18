using Microsoft.AspNetCore.Mvc;
using NotificationsEmail.Contracts;
using NotificationsEmail.Services.Interfaces;
using System.Threading.Tasks;

namespace NotificationsEmail.API.Controllers
{
    /// <summary>
    /// API Сервиса нотификации с помощью отправки Email
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsEmailController : ControllerBase
    {
        private readonly INotificationEmailService _notificationEmailService;

        /// <summary>
        /// API контроллер сервиса нотификации
        /// </summary>
        /// <param name="notificationEmailService"></param>
        public NotificationsEmailController(INotificationEmailService notificationEmailService)
        {
            _notificationEmailService = notificationEmailService;
        }

        /// <summary>
        /// Отправить Email
        /// </summary>
        /// <param name="dto">Письмо</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromForm] LetterDto dto)
        {
            if (ModelState.IsValid)
            {
                await _notificationEmailService.SendNewEmailAsync(dto);
                return Ok();
            }
            return BadRequest();
        }
    }
}
