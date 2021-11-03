using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.UserFiles.Domain.Exceptions;
using Sev1.UserFiles.Application.Exceptions.Category;
using Sev1.UserFiles.Application.Exceptions.Advertisement;

namespace Sev1.UserFiles.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// Проверка удачного восстановления категории модератором
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_ByModerator_Returns_Response_Success(
            int id,
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

            // "Достаем" категорию из базы
            var category = new Domain.Category()
            {
                Name = "Category"
            };
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Сохраняем" категорию в базу
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = id);

            // Act
            await _categoryServiceV1.Restore(
                id,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка удачного восстановления категории админом
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_ByAdministrator_Returns_Response_Success(
            int id,
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

            // "Достаем" категорию из базы
            var category = new Domain.Category()
            {
                Name = "Category"
            };
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _categoryId,
                    CancellationToken ct) => category.Id = id)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Сохраняем" категорию в базу
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = id);

            // Act
            await _categoryServiceV1.Restore(
                id,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка исключения, если обычный пользователь 
        /// хочет восстановить категорию
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_No_Rights(
            int id,
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

            var category = new Domain.Category()
            {
                Name = "Category"
            };

            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId);

            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = id);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _categoryServiceV1.Restore(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если в базе нет категории с таким Id
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_Category_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Достаем" категорию из базы
            Domain.Category category = null;
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category); // в результате выполнения возвращает объект

            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.Restore(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если не прошли валидацию Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Restore_Throws_Exception_When_Id_Is_Not_Valid(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryIdNotValidException>(
                async () => await _categoryServiceV1.Restore(
                    id,
                    cancellationToken));
        }
    }
}