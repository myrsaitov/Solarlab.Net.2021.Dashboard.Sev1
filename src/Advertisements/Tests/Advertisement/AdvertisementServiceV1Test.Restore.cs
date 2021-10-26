using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="advertisementId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Returns_Response_Success(
            string accessToken,
            int id, 
            CancellationToken cancellationToken, 
            int userId,
            int advertisementId)
        {
            // Arrange
            var advertisement = new Domain.Advertisement()
            {
                //OwnerId = userId.ToString()
            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(advertisement)
                .Callback((
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId)
                .Verifiable();


            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(),
                    It.IsAny<CancellationToken>()))
                .Callback((
                    Domain.Advertisement advertisement,
                    CancellationToken ct) => advertisement.Id = advertisementId);

            // Act
            await _advertisementServiceV1.Restore(
                accessToken,
                id,
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_No_Rights(
            string accessToken,
            int id,
            CancellationToken cancellationToken,
            int userId)
        {
            // Arrange
            var advertisement = new Domain.Advertisement()
            {
                //OwnerId = userId.ToString()
            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserInclude(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(advertisement)
                .Callback((
                    int _advertisementId, 
                    CancellationToken ct) => advertisement.Id = _advertisementId);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Restore(
                    accessToken,
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_Advertisement_Is_Null(
            string accessToken,
            int id ,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Restore(
                    accessToken,
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Restore_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            int id, 
            CancellationToken cancellationToken
            )
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.Restore(
                    accessToken,
                    id, 
                    cancellationToken));
        }
    }
}