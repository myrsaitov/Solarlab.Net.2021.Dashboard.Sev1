using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Contracts.Exceptions.Category;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetById_Returns_Response_Success(
            int id, 
            CancellationToken cancellationToken)
        {
            // Arrange
            var category = new Domain.Category()
            {
                Name = "Category"
            };

            _categoryRepositoryMock
                .Setup(_ => _.FindByIdWithParentAndChilds(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(category) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _categoryServiceV1.GetById(
                id, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.NotEqual(default, response.Id);
        }

        /// <summary>
        /// Проверка исключения на отсутствие категории в базе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetById_Throws_Exception_When_Category_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.GetById(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения на невалидный аргумент
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task GetById_Throws_Exception_When_Request_Is_Null(
            int id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryIdNotValidException>(
                async () => await _categoryServiceV1.GetById(
                    id, 
                    cancellationToken));
        }
    }
}