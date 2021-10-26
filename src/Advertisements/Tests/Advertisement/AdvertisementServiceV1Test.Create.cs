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
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка создания объявления
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Returns_Response_Success(
            string accessToken,
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange
            
            // Чтобы пройти проверку на авторизацию
            _userRepositoryMock
                .Setup(_ => _.GetCurrentUserId(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync("24cb4b25-c819-45ab-8755-d95120fbb868")
                .Verifiable();

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // Объект категории, который "возвращается" из базы
            var category = new Domain.Category();
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category)
                .Callback((
                    int _categoryId, 
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();

            // Id тага, который "возвращается" из базы
            int tagId = 1;
            _tagRepositoryMock
                .Setup(_ => _.FindWhere(
                    It.IsAny<Expression<Func<Domain.Tag, bool>>>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(() => new Domain.Tag()
                {
                    Id = tagId,
                    Body = model.TagBodies[tagId++ - 1]
                })
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Tag>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())); // проверяет, что параметр имеет указанный тип <>

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback((
                    Domain.Advertisement advertisement, 
                    CancellationToken ct) => advertisement.Id = 1); // Id "созданного" объявления

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
        [InlineAutoData(null)] //accessToken = null, а остальное автозаполняется
        public async Task Create_Throws_Exception_When_CurrentUserId_Is_Null(
            string accessToken,
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            {
                // Act
                await Assert.ThrowsAsync<NoRightsException>(
                    async () => await _advertisementServiceV1.Create(
                        accessToken,
                        model,
                        cancellationToken));
            }
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие категории
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_Category_Is_Null(
            string accessToken,
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // ЧТобы пройти проверку на авторизацию
            _userRepositoryMock
                .Setup(_ => _.GetCurrentUserId(
                    It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync("24cb4b25-c819-45ab-8755-d95120fbb868")
                .Verifiable();

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // Чтобы вернуть пустую категорию
            Domain.Category category = null;
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category)
                .Verifiable();

            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Create(
                    accessToken,
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверяет реакцию на невалидный аргумент
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            AdvertisementCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            _userRepositoryMock
                .Setup(_ => _.GetCurrentUserId(
                    It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync("24cb4b25-c819-45ab-8755-d95120fbb868")
                .Verifiable();

            // Act
            await Assert.ThrowsAsync<AdvertisementCreateDtoNotValidException>(
                async () => await _advertisementServiceV1.Create(
                    accessToken,
                    model, 
                    cancellationToken));
        }
    }
}