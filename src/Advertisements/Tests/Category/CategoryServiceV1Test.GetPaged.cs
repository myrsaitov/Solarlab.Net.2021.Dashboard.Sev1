using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;
using Sev1.Advertisements.Application.Exceptions.GetPaged;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// Проверка удачного запроса на пагинацию
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Arrange
            int categoryCount = 3;

            var responce = new List<Domain.Category>();

            for (int categoryId = 1; categoryId <= categoryCount; categoryId++)
            {
                var category = new Domain.Category()
                {
                    Id = categoryId,
                };

                responce.Add(category);
            }

            _categoryRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(categoryCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            _categoryRepositoryMock
                .Setup(_ => _.GetPaged(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(responce) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _categoryServiceV1.GetPaged(
                request, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(categoryCount, response.Total);
            Assert.Equal(categoryCount, response.Items.Count());
            Assert.IsType<CategoryGetPagedResponse>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            int categoryCount = 0;

            var responce = new List<Domain.Category>();

            _categoryRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(categoryCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _categoryServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(categoryCount, response.Total);
            Assert.Equal(categoryCount, response.Items.Count());
            Assert.IsType<CategoryGetPagedResponse>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<GetPagedRequestNotValidException>(
                async () => await _categoryServiceV1.GetPaged(
                    request, 
                    cancellationToken));
        }
    }
}