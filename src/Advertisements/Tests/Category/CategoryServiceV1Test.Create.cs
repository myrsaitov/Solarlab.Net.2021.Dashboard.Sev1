using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.Domain.Base.Exceptions;
using Sev1.Advertisements.AppServices.Services.Category.Exceptions;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// Проверка создания категории админом
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_ByAdministrator_Returns_Response_Success(
            CategoryCreateRequest request,
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

            // "Сохраняет" в базу категорию
            request.Name = "Category"; // Чтобы пройти валидацию
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
               .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = 1); // Id "созданной" категории

            // Act
            var response = await _categoryServiceV1.Create(
                request,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// Проверка создания категории модератором
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_ByModerator_Returns_Response_Success(
            CategoryCreateRequest request,
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

            // "Сохраняет" в базу категорию
            request.Name = "Category"; // Чтобы пройти валидацию
            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
               .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Category category,
                    CancellationToken ct) => category.Id = 1); // Id "созданной" категории

            // Act
            var response = await _categoryServiceV1.Create(
                request,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// Проверка исключения при создании категории юзером
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_ByUser_Throws_Exception_When_No_Rights(
            CategoryCreateRequest request,
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

            // "Сохраняет" в базу категорию
            request.Name = "Category"; // Чтобы пройти валидацию
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
                    request,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения при отсутствии аргумента
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            CategoryCreateRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryCreateDtoNotValidException>(
                async () => await _categoryServiceV1.Create(
                    request,
                    cancellationToken));
        }
    }
}