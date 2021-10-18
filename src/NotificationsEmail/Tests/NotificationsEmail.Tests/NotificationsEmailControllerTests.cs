using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using Moq;
using NotificationsEmail.API.Controllers;
using NotificationsEmail.Contracts;
using NotificationsEmail.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotificationsEmail.Tests
{
    public class NotificationsEmailControllerTests
    {
        private readonly Mock<INotificationEmailService> _notificationEmailService;
        private readonly Mock<ILogger<NotificationsEmailController>> _logger;

        public NotificationsEmailControllerTests()
        {
            _notificationEmailService = new Mock<INotificationEmailService>();
            _logger = new Mock<ILogger<NotificationsEmailController>>();
        }

        [Fact]
        public void SendEmail_Should_Not_TypeOf_Task()
        {
            //Arrange
            var controler = new NotificationsEmailController(_logger.Object, _notificationEmailService.Object);

            //Act

            //Assert
            Assert.True(!controler.SendEmail(It.IsAny<LetterDto>()).GetType().Name.Contains("Task"));
        }
    }
}
