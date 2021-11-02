using Sev1.Advertisements.Application.Contracts.Category;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Category
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
        public async Task Create_ByAdmin_Returns_Response_Success(
            CategoryCreateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

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
            var response = await _categoryServiceV1.Create(
                model,
                cancellationToken);

            // Assert
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
        public async Task Create_ByModerator_Returns_Response_Success(
            CategoryCreateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

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
            var response = await _categoryServiceV1.Create(
                model,
                cancellationToken);

            // Assert
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
        public async Task Create_ByUser_Throws_Exception_When_No_Rights(
            CategoryCreateDto model,
            CancellationToken cancellationToken)
        {
            // Arrange

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
                async () => await _categoryServiceV1.Create(
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
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            CategoryCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryCreateDtoNotValidException>(
                async () => await _categoryServiceV1.Create(
                    model,
                    cancellationToken));
        }
    }
}