using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NotificationsEmail.Contracts;
using NotificationsEmail.Domain.Entities;
using NotificationsEmail.Domain.Enums;
using NotificationsEmail.Mapper;
using NotificationsEmail.Services;
using NotificationsEmail.Services.Interfaces;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xunit;

namespace NotificationsEmail.Tests
{
    public class NotificationsEmailServiceTests
    {
        private readonly Mock<INotificationEmailRepository> _repository;
        private readonly Mock<IEmailSender> _emailSender;
        private readonly Mock<IServiceScopeFactory> _scopeFactory;
        private readonly Mock<IServiceProvider> _serviceProvider;
        private readonly Fixture _fixture;
        private readonly IMapper _mapper;
        private readonly INotificationEmailService _notificationEmailService;

        public NotificationsEmailServiceTests()
        {
            _fixture = new Fixture();
            var config = new MapperConfiguration(mc => mc.AddProfile(new LetterMapperProfile()));
            _mapper = config.CreateMapper();
            _repository = new Mock<INotificationEmailRepository>();
            _emailSender = new Mock<IEmailSender>();
            _scopeFactory = new Mock<IServiceScopeFactory>();
            _serviceProvider = new Mock<IServiceProvider>();
            _notificationEmailService = new NotificationEmailService(_mapper, _scopeFactory.Object);
        }

        [Fact]
        public async Task SendNewEmailAsync_Shuold_Call_RepositoryAddLetterAsync_And_NotificationsEmailServiceSendExistedEmailAndSaveResultAsync()
        {
            //Arrange
            var letterDto = _fixture
                            .Build<LetterDto>()
                            .Create();
            _repository.Setup(r => r.AddLetterAsync(It.IsAny<Letter>())).Verifiable();
            _repository.Setup(r => r.UpdateLetterAsync(It.IsAny<Letter>())).Verifiable();

            _emailSender.Setup(es => es.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            _serviceProvider.As<ISupportRequiredService>()
                .Setup(sp => sp.GetRequiredService(typeof(INotificationEmailRepository)))
                .Returns(_repository.Object);

            _serviceProvider.As<ISupportRequiredService>()
                .Setup(sp => sp.GetRequiredService(typeof(IEmailSender)))
                .Returns(_emailSender.Object);

            var serviceScopeMock = _fixture.Freeze<Mock<IServiceScope>>();

            _scopeFactory.As<IServiceScopeFactory>()
                .Setup(sf => sf.CreateScope())
                .Returns(serviceScopeMock.Object);

            serviceScopeMock.Setup(s => s.ServiceProvider)
                .Returns(_serviceProvider.Object);

            //Act
            await _notificationEmailService.SendNewEmailAsync(letterDto);

            //Assert
            _repository.Verify();
            _scopeFactory.Verify();
            _emailSender.Verify(_ => _.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
            _repository.Verify(_ => _.AddLetterAsync(It.IsAny<Letter>()), Times.Once);
            _repository.Verify(_ => _.UpdateLetterAsync(It.IsAny<Letter>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task SendNewEmailAsync_Shuold_Call_UpdateLetterAsync_With_LetterStatus_Failed()
        {
            //Arrange
            var letterDto = _fixture
                            .Build<LetterDto>()
                            .Create();
            _repository.Setup(r => r.AddLetterAsync(It.IsAny<Letter>())).Verifiable();
            _repository.Setup(r => r.UpdateLetterAsync(It.IsAny<Letter>())).Verifiable();

            _emailSender.Setup(es => es.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new SocketException())
                .Verifiable();

            _serviceProvider.As<ISupportRequiredService>()
                .Setup(sp => sp.GetRequiredService(typeof(INotificationEmailRepository)))
                .Returns(_repository.Object);

            _serviceProvider.As<ISupportRequiredService>()
                .Setup(sp => sp.GetRequiredService(typeof(IEmailSender)))
                .Returns(_emailSender.Object);

            var serviceScopeMock = _fixture.Freeze<Mock<IServiceScope>>();

            _scopeFactory.As<IServiceScopeFactory>()
                .Setup(sf => sf.CreateScope())
                .Returns(serviceScopeMock.Object);

            serviceScopeMock.Setup(s => s.ServiceProvider)
                .Returns(_serviceProvider.Object);

            //Act
            await _notificationEmailService.SendNewEmailAsync(letterDto);

            //Assert
            _repository.Verify();
            _scopeFactory.Verify();
            _emailSender.Verify(_ => _.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
            _repository.Verify(_ => _.AddLetterAsync(It.IsAny<Letter>()), Times.Once);
            _repository.Verify(_ => _.UpdateLetterAsync(It.Is<Letter>(letterDto => letterDto.Status == LetterStatus.Failed)), Times.AtLeastOnce);
        }
    }
}
