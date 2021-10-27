using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Advertisements.Contracts;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного удаления объявления
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Returns_Response_Success(
            string accessToken,
            int id, 
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "24cb4b25-c819-45ab-8755-d95120fbb868",
                Role = "user"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus)
                .Verifiable();

            // "Достаем" объявление из базы
            var advertisement = new Domain.Advertisement()
            {
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithTagsInclude(
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
                    CancellationToken ct) => advertisement.Id = id);

            // Act
            await _advertisementServiceV1.Delete(
                accessToken,
                id, 
                cancellationToken);

            // Assert
            _userRepositoryMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="advertisementId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_No_Rights(
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
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(advertisement)
                .Callback((
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId);

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((
                    Domain.Advertisement advertisement,
                    CancellationToken ct) => advertisement.Id = advertisementId);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    id, 
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Advertisement_Is_Null(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    id, 
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="Id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Delete_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            int Id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    Id, 
                    cancellationToken));
        }
    }
}