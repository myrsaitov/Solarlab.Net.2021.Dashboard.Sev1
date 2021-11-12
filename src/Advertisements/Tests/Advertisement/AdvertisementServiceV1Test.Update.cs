using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Application.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Application.Exceptions.Domain;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Category;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного обновления объявления
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Returns_Response_Success(
            AdvertisementUpdateRequest model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // "Возвращаем" польователя, который "восстанавливает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("24cb4b25-c819-45ab-8755-d95120fbb868") // возвращает в результате выполнения
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
                model,
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
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData] //accessToken = null, а остальное автозаполняется
        public async Task Update_Throws_Exception_When_CurrentUserId_Is_Null(
            AdvertisementUpdateRequest model,
            CancellationToken cancellationToken)
        {
            {
                // Arrange

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

                // "Возвращаем" польователя, который "восстанавливает" это объявление
                _userProviderMock
                    .Setup(_ => _.GetUserId())
                    .Returns(""); // возвращает в результате выполнения
 
                // Act
                await Assert.ThrowsAsync<NoRightsException>(
                    async () => await _advertisementServiceV1.Update(
                        model,
                        cancellationToken));
            }
        }

        /// <summary>
        /// Проверяет реакцию на невалидный аргумент
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            AdvertisementUpdateRequest model,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementUpdateDtoNotValidException>(
                async () => await _advertisementServiceV1.Update(
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка, когда объявление не найдено в базе
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Advertisement_Is_Null(
            AdvertisementUpdateRequest model,
            CancellationToken cancellationToken)
        {
            // Arrange

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
                    model,
                    cancellationToken));
        }


        /// <summary>
        /// Проверяет реакцию на отсутствие категории
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Category_Is_Null(
            AdvertisementUpdateRequest model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти валидацию, правим tags
            model.TagBodies = new string[3] { "111", "222", "333" };

            // "Возвращаем" польователя, который "восстанавливает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("24cb4b25-c819-45ab-8755-d95120fbb868") // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

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
                    model,
                    cancellationToken));
        }
    }
}