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
        public IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        /// <summary>
        /// Инициализация сервиса
        /// После инициализации - вызывается метод проверки неотправленных сообщений без ожидания его выполнения.
        /// </summary>
        public NotificationEmailService(IEmailSender emailSender, 
            IMapper mapper, 
            IEmailSender sender, 
            IServiceScopeFactory scopeFactory)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            _scopeFactory = scopeFactory;
            SendMissingLettersForLastDayAsync();
        }

        /// <inheritdoc/>
        public async Task SendEmailAsync(LetterDto letterDto)
        {
            var letter = _mapper.Map<Letter>(letterDto);
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                await _repository.AddLetterAsync(letter);
            }
            await SendMessageAndSaveResult(letter);
        }
        
        /// <summary>
        /// Отправить письмо и записать результат работы в БД
        /// </summary>
        /// <param name="letter">Письмо</param>
        /// <returns></returns>
        private async Task SendMessageAndSaveResult(Letter letter)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                try
                {
                    letter.Status = LetterStatus.Trying;
                    await _repository.UpdateLetterAsync(letter);
                    await _emailSender.SendEmailAsync(letter.EmailAddress, letter.Subject, letter.Body);
                    letter.Status = LetterStatus.Sent;
                }
                catch (Exception e)
                {
                    letter.ErrorMessage = e.Message;
                    letter.Status = LetterStatus.Failed;
                }
                await _repository.UpdateLetterAsync(letter);
            }
        }

        /// <summary>
        /// Загрузка неотправленных писем из бд для повторной попытки отправки.
        /// Из БД загружаются все письма со статусом New && Trying за последние сутки
        /// </summary>
        private async Task SendMissingLettersForLastDayAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<INotificationEmailRepository>();
                var letters = await _repository.GetNotSendedLettersForLastDay();
                foreach (Letter letter in letters)
                {
                    await SendMessageAndSaveResult(letter);
                }
            }
        }
    }
}