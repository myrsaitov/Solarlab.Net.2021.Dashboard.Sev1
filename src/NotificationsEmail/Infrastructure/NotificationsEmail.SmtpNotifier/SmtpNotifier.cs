using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NotificationsEmail.Services.Interfaces;
using System.Threading.Tasks;

namespace NotificationsEmail.Notification
{
    public class SmtpNotifier : IEmailSender
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Использование параметров из json фала
        /// </summary>
        /// <param name="configuration"></param>
        public SmtpNotifier(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            //Установить имя и адрес отправителя
            emailMessage.From.Add(new MailboxAddress(_configuration.GetSection("EmailName").Value, 
                                                    _configuration.GetSection("EmailAddress").Value));
            //Установить имя и адрес получателя
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            //Тема сообщения
            emailMessage.Subject = subject;
            //Текст сообщения
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                //Использование почтового сервиса
                await client.ConnectAsync(_configuration.GetSection("smtpHost").Value, 
                                        int.Parse(_configuration.GetSection("smtpPort").Value), 
                                        bool.Parse(_configuration.GetSection("smtpUseSsl").Value));
                //Аутентификация в сервисе
                await client.AuthenticateAsync(_configuration.GetSection("smtpLogin").Value, 
                                                _configuration.GetSection("smtpPasswrod").Value);
                //Отправить сообщение
                await client.SendAsync(emailMessage);
                //Отключиться от сервиса
                await client.DisconnectAsync(true);
            }
        }
    }
}
