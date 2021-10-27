using Sev1.Advertisements.Application.Contracts.Advertisement;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Advertisements.Contracts;
using System.Collections.Generic;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного обновления объявления
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Returns_Response_Success(
            string accessToken,
            AdvertisementUpdateDto model,
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
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

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

            // Объект объявления, который "возвращается" из базы
            var advertisement = new Domain.Advertisement()
            {
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithCategoriesAndTags(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId)
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
                    Body = model.TagBodies[tagId++ - 1]
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
            await _advertisementServiceV1.Update(
                accessToken,
                model,
                cancellationToken);

            // Assert
            _userRepositoryMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            _tagRepositoryMock.Verify(); // Вызывался ли данный мок?
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
        public async Task Update_Throws_Exception_When_CurrentUserId_Is_Null(
            string accessToken,
            AdvertisementUpdateDto model,
            CancellationToken cancellationToken)
        {
            {
                // Act
                await Assert.ThrowsAsync<NoRightsException>(
                    async () => await _advertisementServiceV1.Update(
                        accessToken,
                        model,
                        cancellationToken));
            }
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
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            AdvertisementUpdateDto model,
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
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            await Assert.ThrowsAsync<AdvertisementUpdateDtoNotValidException>(
                async () => await _advertisementServiceV1.Update(
                    accessToken,
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка, когда объявление не найдено в базе
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Advertisement_Is_Null(
            string accessToken,
            AdvertisementUpdateDto model,
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
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // Чтобы вернуть пустое объявление
            Domain.Advertisement advertisement = null;
            _advertisementRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Update(
                    accessToken,
                    model,
                    cancellationToken));
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
        public async Task Update_Throws_Exception_When_Category_Is_Null(
            string accessToken,
            AdvertisementUpdateDto model,
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
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // Чтобы вернуть пустую категорию
            Domain.Category category = null;
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Объект объявления, который "возвращается" из базы
            var advertisement = new Domain.Advertisement()
            {
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithCategoriesAndTags(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Update(
                    accessToken,
                    model,
                    cancellationToken));
        }
    }
}

/*
/// <summary>
/// 
/// </summary>
/// <param name="accessToken">JWT Token, который пришел с запросом</param>
/// <param name="request">DTO-модель</param>
/// <param name="cancellationToken">Маркёр отмены</param>
/// <param name="userId"></param>
/// <param name="advertisementId"></param>
/// <param name="categoryId"></param>
/// <returns></returns>
[Theory]
[AutoData]
public async Task Update_Returns_Response_Success(
    string accessToken,
    AdvertisementUpdateDto request,
    CancellationToken cancellationToken,
    int userId,
    int advertisementId,
    int categoryId)
{
    // Arrange
    var category = new Domain.Category()
    {
        Id = categoryId
    };

    var advertisement = new Domain.Advertisement()
    {
        Id = advertisementId,

        CategoryId = categoryId
    };

    int tagId = 1;

    _advertisementRepositoryMock
        .Setup(_ => _.FindByIdWithCategoriesAndTags(
            It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
        .Callback(( // Используем передаваемые в мок аргументы для имитации логики
            int _advertisementId,
            CancellationToken ct) => advertisement.Id = _advertisementId)
        .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository


    _categoryRepositoryMock
        .Setup(_ => _.FindById(
            It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(category) // в результате выполнения возвращает объект
        .Callback(( // Используем передаваемые в мок аргументы для имитации логики
            int _categoryId,
            CancellationToken ct) => category.Id = _categoryId)
        .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository


    _categoryRepositoryMock
        .Setup(_ => _.FindById(
            It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(category) // в результате выполнения возвращает объект
        .Callback(() => category.Id = categoryId) //TODO  // Используем передаваемые в мок аргументы для имитации логики
        .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

    _tagRepositoryMock
        .Setup(_ => _.FindWhere(
            It.IsAny<Expression<Func<Domain.Tag, bool>>>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(() => new Domain.Tag()
        {
            Id = tagId,
            Body = request.TagBodies[tagId++ - 1]
        }) // в результате выполнения возвращает объект
        .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

    _tagRepositoryMock
        .Setup(_ => _.Save(
            It.IsAny<Domain.Tag>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())); // проверяет, что параметр имеет указанный тип <>

    _advertisementRepositoryMock
        .Setup(_ => _.Save(
            It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .Callback(( // Используем передаваемые в мок аргументы для имитации логики
            Domain.Advertisement advertisement,
            CancellationToken ct) => advertisement.Id = advertisementId);

    // Act
    var response = await _advertisementServiceV1.Update(
        accessToken,
        request, 
        cancellationToken);

    // Assert
    _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
    _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
    _tagRepositoryMock.Verify(); // Вызывался ли данный мок?
    Assert.NotNull(response);
    Assert.NotEqual(default, response);
}

/// <summary>
/// 
/// </summary>
/// <param name="accessToken">JWT Token, который пришел с запросом</param>
/// <param name="request">DTO-модель</param>
/// <param name="cancellationToken">Маркёр отмены</param>
/// <param name="userId"></param>
/// <param name="advertisementId"></param>
/// <returns></returns>
[Theory]
[AutoData]
public async Task Update_Throws_Exception_When_Category_is_Null(
    string accessToken,
    AdvertisementUpdateDto request,
    CancellationToken cancellationToken,
    int userId,
    int advertisementId)
{
    // Arrange
    var advertisement = new Domain.Advertisement()
    {
        Id = advertisementId,

    };

    _advertisementRepositoryMock
        .Setup(_ => _.FindByIdWithCategoriesAndTags(
            It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
        .Callback(( // Используем передаваемые в мок аргументы для имитации логики
            int _advertisementId,
            CancellationToken ct) => advertisement.Id = _advertisementId);


    // Act
    await Assert.ThrowsAsync<CategoryNotFoundException>(
        async () => await _advertisementServiceV1.Update(
            accessToken,
            request,
            cancellationToken));
}

/// <summary>
/// 
/// </summary>
/// <param name="accessToken">JWT Token, который пришел с запросом</param>
/// <param name="request">DTO-модель</param>
/// <param name="cancellationToken">Маркёр отмены</param>
/// <param name="userId"></param>
/// <param name="advertisementId"></param>
/// <returns></returns>
[Theory]
[AutoData]
public async Task Update_Throws_Exception_When_No_Rights(
    string accessToken,
    AdvertisementUpdateDto request,
    CancellationToken cancellationToken,
    int userId,
    int advertisementId)
{
    // Arrange
    var advertisement = new Domain.Advertisement()
    {
        Id = advertisementId,
    };

    _advertisementRepositoryMock
        .Setup(_ => _.FindByIdWithCategoriesAndTags(
            It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
            It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
        .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
        .Callback(( // Используем передаваемые в мок аргументы для имитации логики
            int _advertisementId,
            CancellationToken ct) => advertisement.Id = _advertisementId);


    // Act
    await Assert.ThrowsAsync<NoRightsException>(
        async () => await _advertisementServiceV1.Update(
            accessToken,
            request,
            cancellationToken));
}

/// <summary>
/// 
/// </summary>
/// <param name="accessToken">JWT Token, который пришел с запросом</param>
/// <param name="request">DTO-модель</param>
/// <param name="cancellationToken">Маркёр отмены</param>
/// <returns></returns>
[Theory]
[AutoData]
public async Task Update_Throws_Exception_When_Advertisement_Is_Null(
    string accessToken,
    AdvertisementUpdateDto request,
    CancellationToken cancellationToken)
{
    // Act
    await Assert.ThrowsAsync<AdvertisementNotFoundException>(
        async () => await _advertisementServiceV1.Update(
            accessToken,
            request,
            cancellationToken));
}

/// <summary>
/// 
/// </summary>
/// <param name="accessToken">JWT Token, который пришел с запросом</param>
/// <param name="request">DTO-модель</param>
/// <param name="cancellationToken">Маркёр отмены</param>
/// <returns></returns>
[Theory]
[InlineAutoData(null)]
public async Task Update_Throws_Exception_When_Request_Is_Null(
    string accessToken,
    AdvertisementUpdateDto request,
    CancellationToken cancellationToken)
{
    // Act
    await Assert.ThrowsAsync<ArgumentNullException>(
        async () => await _advertisementServiceV1.Update(
            accessToken,
            request, 
            cancellationToken));
}*/
