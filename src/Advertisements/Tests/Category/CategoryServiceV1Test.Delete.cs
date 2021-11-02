using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Category;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// Проверка удачного удаления категории модератором
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_ByModerator_Returns_Response_Success(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

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
            await _categoryServiceV1.Delete(
                id,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка удачного удаления категории админом
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_ByAdmin_Returns_Response_Success(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

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
            await _categoryServiceV1.Delete(
                id,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка исключения, если обычный пользователь 
        /// хочет удалить категорию
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_No_Rights(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

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
                async () => await _categoryServiceV1.Delete(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если в базе нет категории с таким Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Category_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // "Достаем" категорию из базы
            Domain.Category category = null;
            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category); // в результате выполнения возвращает объект

            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.Delete(
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
        public async Task Delete_Throws_Exception_When_Id_Is_Not_Valid(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryIdNotValidException>(
                async () => await _categoryServiceV1.Delete(
                    id,
                    cancellationToken));
        }
    }
}