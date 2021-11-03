using Sev1.UserFiles.Application.Contracts.Category;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.UserFiles.Domain.Exceptions;
using Sev1.UserFiles.Application.Exceptions.Advertisement;

namespace Sev1.UserFiles.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// Проверка создания категории админом
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_ByAdministrator_Returns_Response_Success(
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Проверка" роли администратора (true)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Administrator"))))
                .Returns(true) // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Проверка" роли модератора (false)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Moderator"))))
                .Returns(false) // возвращает в результате выполнения
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

            // "Сохраняет" в базу категорию
            model.Name = "Category"; // Чтобы пройти валидацию
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
               .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = 1); // Id "созданной" категории

            // Act
            var response = await _categoryServiceV1.Update(
                model,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// Проверка создания категории модератором
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_ByModerator_Returns_Response_Success(
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Проверка" роли администратора (false)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Administrator"))))
                .Returns(false) // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Проверка" роли модератора (true)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Moderator"))))
                .Returns(true) // возвращает в результате выполнения
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

            // "Сохраняет" в базу категорию
            model.Name = "Category"; // Чтобы пройти валидацию
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
               .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = 1); // Id "созданной" категории

            // Act
            var response = await _categoryServiceV1.Update(
                model,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// Проверка исключения при создании категории юзером
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_ByUser_Throws_Exception_When_No_Rights(
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Проверка" роли администратора (false)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Administrator"))))
                .Returns(false) // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Проверка" роли модератора (false)
            _userProviderMock
                .Setup(_ => _.IsInRole(It.Is<string>(s => s.Contains("Moderator"))))
                .Returns(false) // возвращает в результате выполнения
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

            // "Сохраняет" в базу категорию
            model.Name = "Category"; // Чтобы пройти валидацию
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
               .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = 1); // Id "созданной" категории

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _categoryServiceV1.Update(
                    model,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения при отсутствии аргумента
        /// </summary>
        /// <param name="model">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            CategoryUpdateDto model,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryUpdateDtoNotValidException>(
                async () => await _categoryServiceV1.Update(
                    model,
                    cancellationToken));
        }
    }
}