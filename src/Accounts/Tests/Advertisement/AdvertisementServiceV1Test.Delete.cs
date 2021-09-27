using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Accounts.Application.Exceptions;
using Sev1.Accounts.Domain.Exceptions;
using Sev1.Accounts.Application.Exceptions.Advertisement;

namespace Sev1.Accounts.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
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
            var content = new Domain.Advertisement()
            {
                //OwnerId = userId.ToString()
            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(
                    It.IsAny<int>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId)
                .Verifiable();

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Advertisement content, CancellationToken ct) => content.Id = contentId);

            // Act
            await _advertisementServiceV1.Delete(
                id, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
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
            var content = new Domain.Advertisement()
            {
                //OwnerId = userId.ToString()
            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId);

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Advertisement content, CancellationToken ct) => content.Id = contentId);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Delete(
                    id, 
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Advertisement_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Delete(
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
                async () => await _advertisementServiceV1.Delete(
                    Id, 
                    cancellationToken));
        }
    }
}
