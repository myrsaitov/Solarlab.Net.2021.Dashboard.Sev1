using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationsEmail.Contracts;
using NotificationsEmail.Domain.Entities;
using NotificationsEmail.Domain.Enums;
using NotificationsEmail.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NotificationsEmail.Services
{
    /// <inheritdoc/>
    public class NotificationEmailService : INotificationEmailService
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        /// <summary>
        /// Инициализация сервиса
        /// </summary>
        public NotificationEmailService(IMapper mapper, 
            IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        /// <inheritdoc/>
        public async Task SendNewEmailAsync(LetterDto letterDto)
        {
            var letter = _mapper.Map<Letter>(letterDto);
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                await _repository.AddLetterAsync(letter);
            }
            await SendExistedEmailAndSaveResult(letter);
        }

        /// <inheritdoc/>
        public async Task SendExistedEmailAndSaveResult(Letter letter)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                var _emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
                try
                {
                    letter.Status = LetterStatus.Trying;
                    await _repository.UpdateLetterAsync(letter);
                    await _emailSender.SendEmailAsync(letter.EmailAddress, letter.Subject, letter.Body);
                    letter.Status = LetterStatus.Sent;
                    letter.ErrorMessage = string.Empty;
                }
                catch (Exception e)
                {
                    letter.ErrorMessage = e.Message;
                    letter.Status = LetterStatus.Failed;
                }
                await _repository.UpdateLetterAsync(letter);
            }
        }
    }
}