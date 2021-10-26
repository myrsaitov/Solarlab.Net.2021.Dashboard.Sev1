using Sev1.Advertisements.Application.Contracts.Advertisement;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка создания объявления
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Returns_Response_Success(
            string accessToken,
            AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Arrange

            // Id объявления, которое "создается" в базе
            int advertisementId = 1;
            // Id пользователя, который "создает" объявление
            var currentUserId = "24cb4b25-c819-45ab-8755-d95120fbb868";
            // Id тага, который "возвращается" из базы
            int tagId = 1;
            // Объект категории, который "возвращается" из базы
            var category = new Domain.Category();

            _userRepositoryMock
                .Setup(_ => _.GetCurrentUserId(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(currentUserId)
                .Verifiable();

            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((
                    int _categoryId, 
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.FindWhere(
                    It.IsAny<Expression<Func<Domain.Tag, bool>>>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Domain.Tag()
                {
                    Id = tagId,
                    Body = model.TagBodies[tagId++ - 1]
                })
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Tag>(), 
                    It.IsAny<CancellationToken>()));

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), 
                    It.IsAny<CancellationToken>()))
                .Callback((
                    Domain.Advertisement advertisement, 
                    CancellationToken ct) => advertisement.Id = advertisementId);

            // Act
            await _advertisementServiceV1.Create(
                accessToken,
                model, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            _categoryRepositoryMock.Verify();
            _tagRepositoryMock.Verify();
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие аутентификации
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_CurrentUserId_Is_Null(
            string accessToken,
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Create(
                    accessToken,
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие категории
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_Category_Is_Null(
            string accessToken,
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Create(
                    accessToken,
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие аргумента
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.Create(
                    accessToken,
                    model, 
                    cancellationToken));
        }
    }
}