using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Application.Exceptions.Domain;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного создания объявления
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Returns_Response_Success(
            AdvertisementCreateRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти валидацию, правим tags
            request.TagBodies = new string[3] { "111", "222", "333" };

            // Возвращаем польователя, который "создает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("82d7adfc-5a05-475d-a56d-4d9540a6b7d1") // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Объект категории, который "возвращается" из базы
            var category = new Domain.Category();
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _categoryId, 
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Id тага, который "возвращается" из базы
            int tagId = 1;
            // "Поиск" тага в базе
            _tagRepositoryMock
                .Setup(_ => _.FindWhere(
                    It.IsAny<Expression<Func<Domain.Tag, bool>>>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(() => new Domain.Tag()
                {
                    Id = tagId,
                    Body = request.TagBodies[1]
                }) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Сохранение" тага в базе
            _tagRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Tag>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())); // проверяет, что параметр имеет указанный тип <>

            // "Сохранение" объявления в базе
            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Advertisement advertisement, 
                    CancellationToken ct) => advertisement.Id = 1); // Id "созданного" объявления

            // Act
            await _advertisementServiceV1.Create(
                request,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            _tagRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие аутентификации
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData] //accessToken = null, а остальное автозаполняется
        public async Task Create_Throws_Exception_When_CurrentUserId_Is_Null(
            AdvertisementCreateRequest request,
            CancellationToken cancellationToken)
        {
            {
                // Arrange

                // Чтобы пройти валидацию, правим tags
                request.TagBodies = new string[3] { "111", "222", "333" };

                // Возвращаем польователя, который "создает" это объявление
                _userProviderMock
                    .Setup(_ => _.GetUserId())
                    .Returns(""); // возвращает в результате выполнения

                // Act
                await Assert.ThrowsAsync<NoRightsException>(
                    async () => await _advertisementServiceV1.Create(
                        request,
                        cancellationToken));
            }
        }

        /// <summary>
        /// Проверяет реакцию на отсутствие категории
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_Category_Is_Null(
            AdvertisementCreateRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти валидацию, правим tags
            request.TagBodies = new string[3] { "111", "222", "333" };

            // Возвращаем польователя, который "создает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("82d7adfc-5a05-475d-a56d-4d9540a6b7d1") // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Чтобы вернуть пустую категорию
            Domain.Category category = null;
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Create(
                    request,
                    cancellationToken));
        }

        /// <summary>
        /// Проверяет реакцию на невалидный аргумент
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            AdvertisementCreateRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementCreateDtoNotValidException>(
                async () => await _advertisementServiceV1.Create(
                    request, 
                    cancellationToken));
        }
    }
}