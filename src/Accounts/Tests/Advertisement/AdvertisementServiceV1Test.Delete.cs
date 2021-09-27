using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Accounts.Application.Exceptions;
using Sev1.Accounts.Domain.Exceptions;
using Sev1.Accounts.Application.Exceptions.Account;

namespace Sev1.Accounts.Tests.Account
{
    public partial class AccountServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task Delete_Returns_Response_Success(
            int id, 
            CancellationToken cancellationToken, 
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Account()
            {
                //OwnerId = userId.ToString()
            };

            _accountRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(
                    It.IsAny<int>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _accountId, CancellationToken ct) => content.Id = _accountId)
                .Verifiable();

            _accountRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Account>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Account content, CancellationToken ct) => content.Id = contentId);

            // Act
            await _accountServiceV1.Delete(
                id, 
                cancellationToken);

            // Assert
            _accountRepositoryMock.Verify();
        }
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_No_Rights(
            int id,
            CancellationToken cancellationToken,
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Account()
            {
                //OwnerId = userId.ToString()
            };

            _accountRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _accountId, CancellationToken ct) => content.Id = _accountId);

            _accountRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Account>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Account content, CancellationToken ct) => content.Id = contentId);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _accountServiceV1.Delete(
                    id, 
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Account_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AccountNotFoundException>(
                async () => await _accountServiceV1.Delete(
                    id, 
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task Delete_Throws_Exception_When_Request_Is_Null(
            int Id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _accountServiceV1.Delete(
                    Id, 
                    cancellationToken));
        }
    }
}
